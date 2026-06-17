#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Globalization;
using System.IO.Compression;
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

        /// <summary>
        ///     Returns a small inline PNG image used by the modal image preview manual test.
        /// </summary>
        /// <returns>The sample PNG content.</returns>
        public IActionResult SampleImage()
        {
            return File(CreateSamplePngBytes(), "image/png");
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

        private static byte[] CreateSamplePngBytes()
        {
            const int width = 320;
            const int height = 180;
            byte[] pixels = new byte[(width * 4 + 1) * height];
            int offset = 0;

            for (int y = 0; y < height; y++)
            {
                pixels[offset++] = 0;

                for (int x = 0; x < width; x++)
                {
                    pixels[offset++] = (byte)(30 + x * 180 / width);
                    pixels[offset++] = (byte)(95 + y * 110 / height);
                    pixels[offset++] = (byte)(190 - x * 80 / width);
                    pixels[offset++] = 255;
                }
            }

            using MemoryStream compressedStream = new();
            using (ZLibStream zlibStream = new(compressedStream, CompressionLevel.SmallestSize, true))
            {
                zlibStream.Write(pixels);
            }

            using MemoryStream pngStream = new();
            pngStream.Write(new byte[] { 137, 80, 78, 71, 13, 10, 26, 10 });
            WritePngChunk(pngStream, "IHDR", CreatePngHeader(width, height));
            WritePngChunk(pngStream, "IDAT", compressedStream.ToArray());
            WritePngChunk(pngStream, "IEND", Array.Empty<byte>());
            return pngStream.ToArray();
        }

        private static byte[] CreatePngHeader(int width, int height)
        {
            byte[] header = new byte[13];
            WriteUInt32BigEndian(header, 0, (uint)width);
            WriteUInt32BigEndian(header, 4, (uint)height);
            header[8] = 8;
            header[9] = 6;
            header[10] = 0;
            header[11] = 0;
            header[12] = 0;
            return header;
        }

        private static void WritePngChunk(Stream stream, string chunkType, byte[] data)
        {
            byte[] chunkTypeBytes = Encoding.ASCII.GetBytes(chunkType);
            WriteUInt32BigEndian(stream, (uint)data.Length);
            stream.Write(chunkTypeBytes);
            stream.Write(data);
            WriteUInt32BigEndian(stream, CalculateCrc32(chunkTypeBytes, data));
        }

        private static uint CalculateCrc32(byte[] chunkTypeBytes, byte[] data)
        {
            uint crc = 0xffffffff;
            crc = UpdateCrc32(crc, chunkTypeBytes);
            crc = UpdateCrc32(crc, data);
            return crc ^ 0xffffffff;
        }

        private static uint UpdateCrc32(uint crc, byte[] data)
        {
            foreach (byte value in data)
            {
                crc ^= value;

                for (int index = 0; index < 8; index++)
                {
                    crc = (crc & 1) == 1
                        ? 0xedb88320 ^ (crc >> 1)
                        : crc >> 1;
                }
            }

            return crc;
        }

        private static void WriteUInt32BigEndian(Stream stream, uint value)
        {
            stream.WriteByte((byte)(value >> 24));
            stream.WriteByte((byte)(value >> 16));
            stream.WriteByte((byte)(value >> 8));
            stream.WriteByte((byte)value);
        }

        private static void WriteUInt32BigEndian(byte[] buffer, int offset, uint value)
        {
            buffer[offset] = (byte)(value >> 24);
            buffer[offset + 1] = (byte)(value >> 16);
            buffer[offset + 2] = (byte)(value >> 8);
            buffer[offset + 3] = (byte)value;
        }

        #endregion
    }
}
