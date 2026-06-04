#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBBootstrapBuilder;
using NUnit.Framework;

#endregion

namespace DMBBootstrapBuilderUnitTest;

[TestFixture]
public sealed class ResponsiveDisplayHelperTests
{
    [Test]
    public void BuildResponsiveCssCombinesVisibleFromAndUntilClasses()
    {
        string css = ResponsiveDisplayHelper.BuildResponsiveCss(ResponsiveBreakpoint.Md, ResponsiveBreakpoint.Xl);

        Assert.That(css, Is.EqualTo("d-none d-md-block d-block d-xl-none"));
    }

    [Test]
    public void BuildVisibleFromCssReturnsBreakpointClasses()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ResponsiveDisplayHelper.BuildVisibleFromCss(ResponsiveBreakpoint.Xs), Is.Empty);
            Assert.That(ResponsiveDisplayHelper.BuildVisibleFromCss(ResponsiveBreakpoint.Md), Is.EqualTo("d-none d-md-block"));
            Assert.That(ResponsiveDisplayHelper.BuildVisibleFromCss(ResponsiveBreakpoint.Xxl), Is.EqualTo("d-none d-xxl-block"));
        });
    }

    [Test]
    public void BuildVisibleUntilCssReturnsBreakpointClasses()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ResponsiveDisplayHelper.BuildVisibleUntilCss(ResponsiveBreakpoint.Xs), Is.Empty);
            Assert.That(ResponsiveDisplayHelper.BuildVisibleUntilCss(ResponsiveBreakpoint.Lg), Is.EqualTo("d-block d-lg-none"));
            Assert.That(ResponsiveDisplayHelper.BuildVisibleUntilCss(ResponsiveBreakpoint.Xxl), Is.EqualTo("d-block d-xxl-none"));
        });
    }
}