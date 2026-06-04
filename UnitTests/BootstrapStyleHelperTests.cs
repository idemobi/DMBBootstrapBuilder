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
public sealed class BootstrapStyleHelperTests
{
    [Test]
    public void GapAndJustifyHelpersReturnExpectedClasses()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Old_Gap.Gap3.GetGapCss(), Is.EqualTo("gap-3"));
            Assert.That(Old_Gap.Default.GetGapCss(), Is.Empty);
            Assert.That(JustifyContent.Center.GetJustifyCss(), Is.EqualTo("justify-content-center"));
            Assert.That(JustifyContent.Evenly.GetJustifyCss(), Is.EqualTo("justify-content-evenly"));
            Assert.That(JustifyContent.Default.GetJustifyCss(), Is.Empty);
        });
    }

    [Test]
    public void VariantHelpersReturnExpectedBootstrapClasses()
    {
        Assert.Multiple(() =>
        {
            Assert.That(VariantStyle.Primary.GetOldVariantCss(), Is.EqualTo("primary"));
            Assert.That(VariantStyle.Warning.GetBtnVariantCss(), Is.EqualTo("btn-warning"));
            Assert.That(VariantStyle.Warning.GetBtnVariantCss(outline: true), Is.EqualTo("btn-outline-warning"));
            Assert.That(BootstrapStyleHelper.GetSwitchStyleCss(VariantStyle.Danger), Is.EqualTo("dmb-switch-danger"));
            Assert.That(BootstrapStyleHelper.GetSwitchStyleCss(VariantStyle.Normal), Is.EqualTo("dmb-switch-primary"));
        });
    }
}