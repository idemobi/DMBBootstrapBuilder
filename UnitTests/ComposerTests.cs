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
public sealed class ComposerTests
{
    [Test]
    public void BadgeComposerBuildsBadgeClasses()
    {
        BadgeComposer composer = new BadgeComposer()
            .SetVariant(VariantStyle.Success)
            .SetPill();

        IReadOnlyList<string> classes = composer.BuildClasses();

        Assert.That(classes, Is.EqualTo(new[] { "badge", "text-bg-success", "rounded-pill" }));
    }

    [Test]
    public void BadgeComposerNotificationUsesPositionAndBackgroundClasses()
    {
        BadgeComposer composer = new BadgeComposer()
            .SetVariant(VariantStyle.Danger)
            .SetAsNotification();

        IReadOnlyList<string> classes = composer.BuildClasses();

        Assert.That(classes, Is.EqualTo(new[]
        {
            "badge",
            "position-absolute top-0 start-100 translate-middle p-2 rounded-circle border border-light",
            "bg-danger"
        }));
    }

    [Test]
    public void ComposerCloneKeepsIndependentState()
    {
        ProgressBarComposer composer = new ProgressBarComposer()
            .SetVariant(VariantStyle.Warning)
            .SetStriped();
        IIsCssClassComposer clone = composer.Clone();

        composer.SetVariant(VariantStyle.Success).SetAnimated();

        Assert.Multiple(() =>
        {
            Assert.That(clone.BuildClasses(), Is.EqualTo(new[] { "progress-bar", "bg-warning", "progress-bar-striped" }));
            Assert.That(composer.BuildClasses(), Is.EqualTo(new[] { "progress-bar", "bg-success", "progress-bar-striped", "progress-bar-animated" }));
        });
    }

    [Test]
    public void ProgressBarComposerAnimatedImpliesStriped()
    {
        ProgressBarComposer composer = new ProgressBarComposer()
            .SetVariant(VariantStyle.Info)
            .SetAnimated();

        IReadOnlyList<string> classes = composer.BuildClasses();

        Assert.That(classes, Is.EqualTo(new[]
        {
            "progress-bar",
            "bg-info",
            "progress-bar-striped",
            "progress-bar-animated"
        }));
    }
}