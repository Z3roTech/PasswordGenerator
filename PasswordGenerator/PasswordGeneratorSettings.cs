namespace ZeroCode
{
    /// <summary>
    ///     Settings model for password generator configuring
    /// </summary>
    public class PasswordGeneratorSettings
    {
        /// <summary>
        ///     Use lower-case chars
        /// </summary>
        public bool LowerCase { get; set; }

        /// <summary>
        ///     Use upper-case chars
        /// </summary>
        public bool UpperCase { get; set; }

        /// <summary>
        ///     Use digit chars
        /// </summary>
        public bool Digits { get; set; }

        /// <summary>
        ///     Use special chars
        /// </summary>
        public bool SpecialChars { get; set; }
    }
}