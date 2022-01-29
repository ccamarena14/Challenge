using Challenge.Common.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Common
{
    public class FileCommon
    {
        /// <summary>
        /// Read and return data from a file in a string[]
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns></returns>
        public static bool FileExists(ref string path)
        {
            try
            {
                if (!File.Exists(Path.Combine(path, "challenge.in")))
                {
                    Console.WriteLine($"Invalid path, the internal file will be processed.");
                    path = StringCommon.Instance.InputFileName;
                }
                if (string.IsNullOrEmpty(path))
                {
                    Console.WriteLine($"Internal file will be processed.");
                    path = StringCommon.Instance.InputFileName;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to find file challenge.in. {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Read and return data from a file in a string[]
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>return string[] data</returns>
        public static async Task<IList<string>> ReadFile(string path)
        {
            try
            {
                var arrData = await File.ReadAllLinesAsync(path);
                return GetListWithoutSpaces(arrData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file. {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Remove spaces in Array
        /// </summary>
        /// <param name="arrData">Array string with data</param>
        /// <returns>return string list</returns>
        public static IList<string> GetListWithoutSpaces(string[] arrData)
        {
            try
            {
                var items = new List<string>();
                foreach (string arrItem in arrData)
                {
                    items.Add(arrItem.RemoveSpaces());
                }
                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing spaces. {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Validate format file. Without spaces and multiple of three
        /// </summary>
        /// <param name="arrData">Array string with data</param>
        /// <returns></returns>
        public static bool ValidateFormatFile(IList<string> arrData)
        {
            try
            {
                if (arrData.All(item => string.IsNullOrEmpty(item)))
                {
                    Console.WriteLine("The file is not in the correct format.has blank lines"); return false;
                }
                if (arrData.Count % 3 != 0) { Console.WriteLine($"File with invalid format. Total lines: {arrData.Count}."); return false; }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error validate format file. {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Save file from list
        /// </summary>
        /// <param name="arrData">List of devices with tasks</param>
        /// <returns>Return true if save the file otherwise false</returns>
        public static async Task<bool> SaveFile(List<Tuple<int, StringBuilder>> arrData)
        {
            try
            {
                Console.Write("Enter output file path: ");
                var path = Console.ReadLine();
                if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
                {
                    path = AppDomain.CurrentDomain.BaseDirectory;
                    Console.WriteLine($"Invalid path, the output file will be created in: {path}");
                }

                using (var file = new StreamWriter(Path.Combine(path, StringCommon.Instance.OutputFileName), false))
                {
                    foreach (var item in arrData)
                    {
                        await file.WriteLineAsync(item.Item2.ToString());
                    }
                }
                Console.WriteLine($"Output file successfully created in: {Path.Combine(path, StringCommon.Instance.OutputFileName)}");
                return true;
            }
            catch (Exception ex)
            {
                Console.Write($"Failed to crate file challenge.out. {ex.Message}.");
                return false; ;
            }
        }
    }
}
