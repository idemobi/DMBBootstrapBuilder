#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBBootstrapBuilder;
using DMBPageBuilder;
using NUnit.Framework;

#endregion

namespace DMBBootstrapBuilderUnitTest;

[TestFixture]
public sealed class VariantStyleExtensionTests
{
    [Test]
    public void OldVariantExtensionsKeepLegacyClasses()
    {
        Assert.Multiple(() =>
        {
            Assert.That(VariantStyle.Primary.GetOldBackgroundCssClass(), Is.EqualTo("bg-primary"));
            Assert.That(VariantStyle.Light.GetOldBackgroundCssClass(), Is.EqualTo("bg-primary"));
            Assert.That(VariantStyle.Danger.GetOldSuffixCssClass(), Is.EqualTo("-danger"));
            Assert.That(VariantStyle.Info.GetOldTextCssClass(), Is.EqualTo("text-info"));
        });
    }

    [Test]
    public void RecommendedTextVariantMatchesReadableForeground()
    {
        Assert.Multiple(() =>
        {
            Assert.That(VariantStyle.Primary.GetRecommendedTextVariant(), Is.EqualTo(VariantStyle.Light));
            Assert.That(VariantStyle.Warning.GetRecommendedTextVariant(), Is.EqualTo(VariantStyle.Dark));
            Assert.That(VariantStyle.Info.GetRecommendedTextVariant(), Is.EqualTo(VariantStyle.Dark));
            Assert.That(VariantStyle.Normal.GetRecommendedTextVariant(), Is.Null);
        });
    }

    [Test]
    public void VariantInternalExtensionsReturnExpectedClasses()
    {
        Assert.Multiple(() =>
        {
            Assert.That(VariantStyle.Primary.GetVariantCss(), Is.EqualTo("primary"));
            Assert.That(VariantStyle.Normal.GetVariantCss(), Is.Empty);
            Assert.That(VariantStyle.Success.GetBackgroundCssClass(), Is.EqualTo("bg-success"));
            Assert.That(VariantStyle.Success.GetBackgroundCssClass(subtle: true), Is.EqualTo("bg-success-subtle"));
            Assert.That(VariantStyle.Dark.GetTextCssClass(emphasis: false), Is.EqualTo("text-dark"));
            Assert.That(VariantStyle.Dark.GetTextCssClass(emphasis: true), Is.EqualTo("text-dark-emphasis"));
        });
    }
}