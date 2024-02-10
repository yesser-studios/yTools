namespace yTools
{
    public static class Booleans
    {
        /// <summary>
        /// The true boolean value.
        /// </summary>
        public const bool True = true;

        /// <summary>
        /// The false boolean value.
        /// </summary>
        public const bool False = false;

        /// <summary>
        /// Returns the opposite of the given boolean value.
        /// </summary>
        public static bool Invert(bool input) => !input;
    }
}
