using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ZeroCode
{
    /// <summary>
    ///     Configurable implementation of password generator
    /// </summary>
    internal class ConfigurablePasswordGenerator : IConfigurablePasswordGenerator
    {
        /// <summary>
        ///     Chars that must be used for password generation
        /// </summary>
        internal readonly char[][] ConfiguredChars =
        {
            Array.Empty<char>(),
            Array.Empty<char>(),
            Array.Empty<char>(),
            Array.Empty<char>()
        };

        public ConfigurablePasswordGenerator(PasswordGeneratorSettings generatorSettings)
        {
            if (generatorSettings.UpperCase) UseUpperCase();
            if (generatorSettings.LowerCase) UseLowerCase();
            if (generatorSettings.Digits) UseDigits();
            if (generatorSettings.SpecialChars) UseSpecialChars();
        }

        /// <inheritdoc />
        public string Generate(int length = PasswordGenerator.LowSecurityPasswordLength)
        {
            var passwordChars = ConfiguredChars.SelectMany(chars => chars).ToArray();
            if (length <= 0)
                throw new ArgumentOutOfRangeException(nameof(length), "Length of the password can not be negative");

            if (length <= PasswordGenerator.LowSecurityPasswordLength)
                throw new ArgumentOutOfRangeException(nameof(length),
                    $"Length of the password must be more then {PasswordGenerator.LowSecurityPasswordLength}");

            var passwordBuilder = new StringBuilder(length);
            for (var i = 0; i < length; i++)
                passwordBuilder.Append(passwordChars[RandomNumberGenerator.GetInt32(passwordChars.Length)]);

            return passwordBuilder.ToString();
        }

        /// <inheritdoc />
        public IConfigurablePasswordGenerator UseLowerCase()
        {
            ConfiguredChars[0] = PasswordGenerator.LowerChars;
            return this;
        }

        /// <inheritdoc />
        public IConfigurablePasswordGenerator UseUpperCase()
        {
            ConfiguredChars[1] = PasswordGenerator.UpperChars;
            return this;
        }

        /// <inheritdoc />
        public IConfigurablePasswordGenerator UseDigits()
        {
            ConfiguredChars[2] = PasswordGenerator.DigitChars;
            return this;
        }

        /// <inheritdoc />
        public IConfigurablePasswordGenerator UseSpecialChars()
        {
            ConfiguredChars[3] = PasswordGenerator.SpecialChars;
            return this;
        }
    }
}