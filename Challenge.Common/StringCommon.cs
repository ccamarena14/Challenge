namespace Challenge.Common
{
    /// <summary>
    /// String Common Instance
    /// </summary>
    public class StringCommon
    {
        #region Singleton
        private static readonly StringCommon _instance = new StringCommon();
        public static StringCommon Instance { get { return _instance; } }
        #endregion

        public string[] arrayDelimiter = { "),(", "(", ")" };
        public string InputFileName = "challenge.in";
        public string OutputFileName = "challenge.out";
    }
}
