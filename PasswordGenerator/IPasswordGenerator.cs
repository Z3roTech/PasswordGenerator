namespace ZeroCode
{
    /// <summary>
    ///     Interface of password generator
    /// </summary>
    public interface IPasswordGenerator
    {
        /// <summary>
        ///     Return randomly generated password using setup chars
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        string Generate(int length = PasswordGenerator.LowSecurityPasswordLength);
    }
}