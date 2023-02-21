namespace yTools
{
    public static class General
    {
        /// <summary>
        /// Returns the given input of any type.
        /// </summary>
        public static T GetInput<T>(T input) => input;

        /// <summary>
        /// Closes your app with an exit code. The default exit code is 0.
        /// </summary>
        public static void CloseApp(int exitCode = 0)
        {
            Environment.Exit(exitCode);
        }
    }
}