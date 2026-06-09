#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace DMBBootstrapBuilderLabs.Models
{
    /// <summary>
    ///     Represents the form payload used by the page-alert validation examples.
    /// </summary>
    public class PageAlertFormExample
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the submitted age.
        /// </summary>
        [Range(18, 130, ErrorMessage = "Age must be between 18 and 130.")]
        public int? Age { get; set; }

        /// <summary>
        ///     Gets or sets the submitted email address.
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email must be a valid email address.")]
        public string? Email { get; set; }

        /// <summary>
        ///     Gets or sets the submitted display name.
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        #endregion
    }
}