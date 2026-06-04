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
public sealed class ProgressBarSizeTests
{
    [Test]
    public void GetSizeAndUnitStyleReturnsExpectedCssSizes()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ProgressBarSize.Thin.GetSizeAndUnitStyle(), Is.EqualTo("1px"));
            Assert.That(ProgressBarSize.Small.GetSizeAndUnitStyle(), Is.EqualTo("0.375rem"));
            Assert.That(ProgressBarSize.Medium.GetSizeAndUnitStyle(), Is.EqualTo("1rem"));
            Assert.That(ProgressBarSize.Large.GetSizeAndUnitStyle(), Is.EqualTo("1.5rem"));
            Assert.That(ProgressBarSize.Thick.GetSizeAndUnitStyle(), Is.EqualTo("2rem"));
        });
    }
}