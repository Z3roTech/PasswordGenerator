namespace ZeroCode
{
    /// <summary>
    ///     Interface of the configurable generators
    /// </summary>
    internal interface IConfigurablePasswordGenerator : IPasswordGenerator
    {
        /// <summary>
        ///     Setup using lower case chars for password generation
        /// </summary>
        /// <returns></returns>
        IConfigurablePasswordGenerator UseLowerCase();

        /// <summary>
        ///     Setup using upper case chars for password generation
        /// </summary>
        /// <returns></returns>
        IConfigurablePasswordGenerator UseUpperCase();

        /// <summary>
        ///     Setup using digit chars for password generation
        /// </summary>
        /// <returns></returns>
        IConfigurablePasswordGenerator UseDigits();

        /// <summary>
        ///     Setup using special chars for password generation
        /// </summary>
        /// <returns></returns>
        IConfigurablePasswordGenerator UseSpecialChars();
    }
}