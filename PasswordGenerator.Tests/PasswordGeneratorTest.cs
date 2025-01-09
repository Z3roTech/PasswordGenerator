using ZeroCode;

namespace PasswordGenerator.Tests;

[TestFixture]
[TestOf(typeof(ZeroCode.PasswordGenerator))]
public class PasswordGeneratorTest
{
    [Test]
    public void PasswordGenerationTest()
    {
        var generator = ZeroCode.PasswordGenerator
            .UseDigits()
            .UseDigits() // Does nothing, because it's already use digits
            .UseLowerCase()
            .UseSpecialChars()
            .UseUpperCase();

        var cpg = generator as ConfigurablePasswordGenerator;

        Assert.That(cpg.ConfiguredChars, Has.ItemAt(0).EqualTo(ZeroCode.PasswordGenerator.LowerChars));
        Assert.That(cpg.ConfiguredChars, Has.ItemAt(1).EqualTo(ZeroCode.PasswordGenerator.UpperChars));
        Assert.That(cpg.ConfiguredChars, Has.ItemAt(2).EqualTo(ZeroCode.PasswordGenerator.DigitChars));
        Assert.That(cpg.ConfiguredChars, Has.ItemAt(3).EqualTo(ZeroCode.PasswordGenerator.SpecialChars));

        var password = generator.Generate(ZeroCode.PasswordGenerator.ExtremeSecurityPasswordLength);
        Assert.That(password, Has.Length.EqualTo(ZeroCode.PasswordGenerator.ExtremeSecurityPasswordLength));

        Assert.That(ZeroCode.PasswordGenerator.GetDefault(), Is.Not.Null);
        Assert.That(ZeroCode.PasswordGenerator.GetGenerator(settings => settings.Digits = true), Is.Not.Null);
        Assert.That(ZeroCode.PasswordGenerator.UseDigits(), Is.Not.Null);
        Assert.That(ZeroCode.PasswordGenerator.UseLowerCase(), Is.Not.Null);
        Assert.That(ZeroCode.PasswordGenerator.UseUpperCase(), Is.Not.Null);
        Assert.That(ZeroCode.PasswordGenerator.UseSpecialChars(), Is.Not.Null);
    }
}