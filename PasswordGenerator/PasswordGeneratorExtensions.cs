namespace ZeroCode
{
    /// <summary>
    ///     Extensions for configuring password generator
    /// </summary>
    public static class PasswordGeneratorExtensions
    {
        /// <inheritdoc cref="PasswordGenerator.UseLowerCase(IPasswordGenerator)" />
        public static IPasswordGenerator UseLowerCase(this IPasswordGenerator generator)
        {
            return PasswordGenerator.UseLowerCase(generator);
        }

        /// <inheritdoc cref="PasswordGenerator.UseUpperCase(IPasswordGenerator)" />
        public static IPasswordGenerator UseUpperCase(this IPasswordGenerator generator)
        {
            return PasswordGenerator.UseUpperCase(generator);
        }

        /// <inheritdoc cref="PasswordGenerator.UseDigits(IPasswordGenerator)" />
        public static IPasswordGenerator UseDigits(this IPasswordGenerator generator)
        {
            return PasswordGenerator.UseDigits(generator);
        }

        /// <inheritdoc cref="PasswordGenerator.UseSpecialChars(IPasswordGenerator)" />
        public static IPasswordGenerator UseSpecialChars(this IPasswordGenerator generator)
        {
            return PasswordGenerator.UseSpecialChars(generator);
        }
    }
}