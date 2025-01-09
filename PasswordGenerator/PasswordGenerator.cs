using System;

namespace ZeroCode
{
    /// <summary>
    ///     General utility for creating instances of password generators
    /// </summary>
    public static class PasswordGenerator
    {
        /// <summary>
        ///     Length of password that grades as "Low Security"
        /// </summary>
        public const int LowSecurityPasswordLength = 8;

        /// <summary>
        ///     Length of password that grades as "Medium security"
        /// </summary>
        public const int MediumSecurityPasswordLength = 16;

        /// <summary>
        ///     Length of password that grades as "High security"
        /// </summary>
        public const int HighSecurityPasswordLength = 24;

        /// <summary>
        ///     Length of password that grades as "Very high security"
        /// </summary>
        public const int ExtremeSecurityPasswordLength = 32;

        /// <summary>
        ///     Prepared array with upper-case chars
        /// </summary>
        internal static readonly char[] UpperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        /// <summary>
        ///     Prepared array with lower-case chars
        /// </summary>
        internal static readonly char[] LowerChars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        /// <summary>
        ///     Prepared array with digit chars
        /// </summary>
        internal static readonly char[] DigitChars = "0123456789".ToCharArray();

        /// <summary>
        ///     Prepared array with special chars
        /// </summary>
        internal static readonly char[] SpecialChars = "!\"#$%&'*+,./:;=?@\\^`|~".ToCharArray();

        /// <summary>
        ///     Returns new password generator with default settings (low-case, upper-case and digits)
        /// </summary>
        /// <returns></returns>
        public static IPasswordGenerator GetDefault()
        {
            return new ConfigurablePasswordGenerator(new PasswordGeneratorSettings
            {
                LowerCase = true,
                UpperCase = true,
                Digits = true
            });
        }

        /// <summary>
        ///     Returns new password generator with custom settings
        /// </summary>
        /// <param name="configurationFactory"></param>
        /// <returns></returns>
        public static IPasswordGenerator GetGenerator(Action<PasswordGeneratorSettings> configurationFactory)
        {
            var settings = new PasswordGeneratorSettings();
            configurationFactory(settings);
            return new ConfigurablePasswordGenerator(settings);
        }

        /// <summary>
        ///     Returns new password generator that uses lower-case chars
        /// </summary>
        /// <returns></returns>
        public static IPasswordGenerator UseLowerCase()
        {
            return new ConfigurablePasswordGenerator(new PasswordGeneratorSettings
            {
                LowerCase = true
            });
        }

        /// <summary>
        ///     Returns new password generator that uses upper-case chars
        /// </summary>
        /// <returns></returns>
        public static IPasswordGenerator UseUpperCase()
        {
            return new ConfigurablePasswordGenerator(new PasswordGeneratorSettings
            {
                UpperCase = true
            });
        }

        /// <summary>
        ///     Returns new password generator that uses digit chars
        /// </summary>
        /// <returns></returns>
        public static IPasswordGenerator UseDigits()
        {
            return new ConfigurablePasswordGenerator(new PasswordGeneratorSettings
            {
                Digits = true
            });
        }

        /// <summary>
        ///     Returns new password generator that uses special chars
        /// </summary>
        /// <returns></returns>
        public static IPasswordGenerator UseSpecialChars()
        {
            return new ConfigurablePasswordGenerator(new PasswordGeneratorSettings
            {
                SpecialChars = true
            });
        }

        /// <summary>
        ///     Configure generator to use lower-case chars
        /// </summary>
        /// <param name="generator"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        internal static IPasswordGenerator UseLowerCase(IPasswordGenerator generator)
        {
            if (generator is not IConfigurablePasswordGenerator configurable)
                throw new InvalidOperationException("This generator can not be configure!");

            return configurable.UseLowerCase();
        }

        /// <summary>
        ///     Configure generator to use upper-case chars
        /// </summary>
        /// <param name="generator"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        internal static IPasswordGenerator UseUpperCase(IPasswordGenerator generator)
        {
            if (generator is not IConfigurablePasswordGenerator configurable)
                throw new InvalidOperationException("This generator can not be configure!");

            return configurable.UseUpperCase();
        }

        /// <summary>
        ///     Configure generator to use digit chars
        /// </summary>
        /// <param name="generator"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        internal static IPasswordGenerator UseDigits(IPasswordGenerator generator)
        {
            if (generator is not IConfigurablePasswordGenerator configurable)
                throw new InvalidOperationException("This generator can not be configure!");

            return configurable.UseDigits();
        }

        /// <summary>
        ///     Configure generator to use special chars
        /// </summary>
        /// <param name="generator"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        internal static IPasswordGenerator UseSpecialChars(IPasswordGenerator generator)
        {
            if (generator is not IConfigurablePasswordGenerator configurable)
                throw new InvalidOperationException("This generator can not be configure!");

            return configurable.UseSpecialChars();
        }
    }
}