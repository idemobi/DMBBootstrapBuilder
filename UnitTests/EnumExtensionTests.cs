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
public sealed class EnumExtensionTests
{
    [Test]
    public void ButtonSizeExtensionReturnsExpectedClasses()
    {
        Assert.Multiple(() =>
        {
            Assert.That(BoostrapButtonSize.Small.GetBtnSizeCss(), Is.EqualTo("btn-sm"));
            Assert.That(BoostrapButtonSize.Medium.GetBtnSizeCss(), Is.Empty);
            Assert.That(BoostrapButtonSize.Large.GetBtnSizeCss(), Is.EqualTo("btn-lg"));
        });
    }

    [Test]
    public void ContainerAndBreadcrumbExtensionsReturnExpectedClasses()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ContainerStyle.None.GetCss(), Is.Empty);
            Assert.That(ContainerStyle.Default.GetCss(), Is.EqualTo("container"));
            Assert.That(ContainerStyle.Fluid.GetCss(), Is.EqualTo("container-fluid"));
            Assert.That(ContainerStyle.Xxl.GetCss(), Is.EqualTo("container-xxl"));
            Assert.That(ContainerStyle.LandingPage.GetCss(), Is.EqualTo("landing-page"));
            Assert.That(BreadcrumbStyle.Default.GetCssClass(), Is.Empty);
            Assert.That(BreadcrumbStyle.Subtle.GetCssClass(), Is.EqualTo("breadcrumb-minimal"));
        });
    }

    [Test]
    public void ResponsiveBreakpointExtensionsReturnExpectedTokens()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ResponsiveBreakpoint.Xs.GetCss(), Is.Empty);
            Assert.That(ResponsiveBreakpoint.Md.GetCss(), Is.EqualTo("md"));
            Assert.That(ResponsiveBreakpoint.Xxl.GetCss(), Is.EqualTo("xxl"));
            Assert.That(ResponsiveBreakpoint.Xs.GetPrefixCss(), Is.Empty);
            Assert.That(ResponsiveBreakpoint.Lg.GetPrefixCss(), Is.EqualTo("-lg"));
        });
    }

    [Test]
    public void SpinnerExtensionsReturnExpectedClasses()
    {
        Assert.Multiple(() =>
        {
            Assert.That(SpinnerType.Border.GetCssClass(), Is.EqualTo("spinner-border"));
            Assert.That(SpinnerType.Grow.GetCssClass(), Is.EqualTo("spinner-grow"));
            Assert.That(SpinnerSize.Small.GetCssClass(SpinnerType.Border), Is.EqualTo("spinner-border-sm"));
            Assert.That(SpinnerSize.Small.GetCssClass(SpinnerType.Grow), Is.EqualTo("spinner-grow-sm"));
            Assert.That(SpinnerSize.Default.GetCssClass(SpinnerType.Border), Is.Empty);
            Assert.That(SpinnerSize.Small.ClassToClean(), Is.EqualTo(new[] { "spinner-grow-sm", "spinner-border-sm" }));
        });
    }
}