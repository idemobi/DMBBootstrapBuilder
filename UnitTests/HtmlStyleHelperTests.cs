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
public sealed class HtmlStyleHelperTests
{
    [TestCase(null, "color: red", "color: red")]
    [TestCase("", "color: red", "color: red")]
    [TestCase("margin: 0", "", "margin: 0")]
    [TestCase("margin: 0", "color: red", "margin: 0; color: red")]
    [TestCase("margin: 0;", "color: red", "margin: 0; color: red")]
    public void MergeStyleComposesCssDeclarations(string? currentStyle, string appendedStyle, string expected)
    {
        string result = HtmlStyleHelper.MergeStyle(currentStyle, appendedStyle);

        Assert.That(result, Is.EqualTo(expected));
    }
}