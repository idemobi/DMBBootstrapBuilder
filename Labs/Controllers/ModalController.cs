#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Globalization;
using System.Text;
using DMBBootstrapBuilder;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DMBBootstrapBuilderLabs.Controllers
{
    /// <summary>
    ///     Provides live examples for the modal component.
    /// </summary>
    public class ModalController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the modal example page.
        /// </summary>
        /// <returns>The modal example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     Renders the injected modal fragment used by the PDF preview manual test.
        /// </summary>
        /// <returns>The injected PDF preview modal partial view.</returns>
        public IActionResult PdfPreviewFragment()
        {
            return PartialView("~/Views/Shared/Examples/Modal/_ModalPdfPreviewFragment.cshtml");
        }

        /// <summary>
        ///     Returns a small inline PDF document used by the modal PDF preview manual test.
        /// </summary>
        /// <returns>The sample PDF content.</returns>
        public IActionResult SamplePdf()
        {
            return File(CreateSamplePdfBytes(), "application/pdf");
        }

        private static byte[] CreateSamplePdfBytes()
        {
            const string content = """
                                   BT
                                   /F1 24 Tf
                                   72 720 Td
                                   (DMBBootstrapBuilder Modal PDF Preview) Tj
                                   0 -36 Td
                                   /F1 12 Tf
                                   (Inline sample document for the labs modal injection test.) Tj
                                   ET
                                   """;

            string[] objects =
            {
                "<< /Type /Catalog /Pages 2 0 R >>",
                "<< /Type /Pages /Kids [3 0 R] /Count 1 >>",
                "<< /Type /Page /Parent 2 0 R /MediaBox [0 0 612 792] /Contents 4 0 R /Resources << /Font << /F1 5 0 R >> >> >>",
                $"<< /Length {Encoding.ASCII.GetByteCount(content).ToString(CultureInfo.InvariantCulture)} >>\nstream\n{content}\nendstream",
                "<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica >>"
            };

            StringBuilder builder = new("%PDF-1.4\n");
            List<int> offsets = new() { 0 };

            for (int index = 0; index < objects.Length; index++)
            {
                offsets.Add(Encoding.ASCII.GetByteCount(builder.ToString()));
                builder.Append(index + 1);
                builder.Append(" 0 obj\n");
                builder.Append(objects[index]);
                builder.Append("\nendobj\n");
            }

            int xrefOffset = Encoding.ASCII.GetByteCount(builder.ToString());
            builder.Append("xref\n");
            builder.Append("0 ");
            builder.Append(objects.Length + 1);
            builder.Append('\n');
            builder.Append("0000000000 65535 f \n");

            foreach (int offset in offsets.Skip(1))
            {
                builder.Append(offset.ToString("D10", CultureInfo.InvariantCulture));
                builder.Append(" 00000 n \n");
            }

            builder.Append("trailer\n");
            builder.Append("<< /Size ");
            builder.Append(objects.Length + 1);
            builder.Append(" /Root 1 0 R >>\n");
            builder.Append("startxref\n");
            builder.Append(xrefOffset.ToString(CultureInfo.InvariantCulture));
            builder.Append("\n%%EOF");

            return Encoding.ASCII.GetBytes(builder.ToString());
        }

        #endregion
    }
}
