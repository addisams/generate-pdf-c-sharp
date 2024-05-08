using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Action;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace generate_pdf_c_sharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
                // Must have write permissions to the path folder
                PdfWriter writer = new PdfWriter("E:\\test\\demo.pdf");
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

                // Header
                Paragraph header = new Paragraph("HEADER")
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetFontSize(20);

                // New line
                Paragraph newline = new Paragraph(new Text("\n"));

                document.Add(newline);
                document.Add(header);

                // Add sub-header
                Paragraph subheader = new Paragraph("SUB HEADER")
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetFontSize(15);
                document.Add(subheader);

                // Line separator
                LineSeparator ls = new LineSeparator(new SolidLine());
                document.Add(ls);

                // Add paragraph1
                Paragraph paragraph1 = new Paragraph("Lorem ipsum " +
                   "dolor sit amet, consectetur adipiscing elit, " +
                   "sed do eiusmod tempor incididunt ut labore " +
                   "et dolore magna aliqua.");
                document.Add(paragraph1);

                // Add image
                //Image img = new Image(ImageDataFactory
                //   .Create(@"..\..\image.jpg"))
                //   .SetTextAlignment(TextAlignment.CENTER);
                //document.Add(img);

                // Table

                string[] arr = { "name", "age", "status", "gender", "class" };
                string[,] arr2 = {
                { "siddhrath1", "30", "married", "male", "upper" },
                {"siddhrath2", "30", "married", "male", "upper"},
                {"siddhrath3", "30", "married", "male", "upper"},
                {"siddhrath4", "30", "married", "male", "upper"},
            };


                Table table = new Table(arr.Length, false);
                for (int i = 0; i < arr.Length; i++)
                {
                    Cell cell11 = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.WHITE)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetFontColor(ColorConstants.BLUE)
                    .Add(new Paragraph(arr[i]));
                    table.AddCell(cell11);
                }
                //Cell cell11 = new Cell(1, 2);
                for (int i = 0; i < arr2.GetLength(0); i++)
                {
                    for (int j = 0; j < arr2.GetLength(1); j++)
                    {
                        Cell cell12 = new Cell(1, 1)
                  .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                  .SetTextAlignment(TextAlignment.CENTER)
                  .SetFontColor(ColorConstants.RED)
                   .Add(new Paragraph(arr2[i, j]));
                        table.AddCell(cell12);
                    }

                }

                //Cell cell12 = new Cell(1, 1)
                //   .SetBackgroundColor(ColorConstants.GRAY)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("Capital"));
                //Cell cell13 = new Cell(1, 1)
                //   .SetBackgroundColor(ColorConstants.GRAY)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("village"));
                //Cell cell14 = new Cell(1, 1)
                //   .SetBackgroundColor(ColorConstants.GRAY)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("city"));
                //Cell cell15 = new Cell(1, 1)
                //   .SetBackgroundColor(ColorConstants.GRAY)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("district"));

                //Cell cell21 = new Cell(1, 1)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("New York"));
                //Cell cell22 = new Cell(1, 1)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("Albany"));
                //Cell cell23 = new Cell(1, 1)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("sarauna"));
                //Cell cell24 = new Cell(1, 1)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("jamalapur"));
                //Cell cell25 = new Cell(1, 1)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("jaunpur"));

                //Cell cell31 = new Cell(1, 1)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("New Jersey"));
                //Cell cell32 = new Cell(1, 1)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("Trenton"));

                //Cell cell41 = new Cell(1, 1)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("California"));
                //Cell cell42 = new Cell(1, 1)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("Sacramento"));


                //table.AddCell(cell12);
                //table.AddCell(cell13);
                //table.AddCell(cell14);
                //table.AddCell(cell15);

                //table.AddCell(cell21);
                //table.AddCell(cell22);
                //table.AddCell(cell23);
                //table.AddCell(cell24);
                //table.AddCell(cell25);

                //table.AddCell(cell31);
                //table.AddCell(cell32);
                //table.AddCell(cell41);
                //table.AddCell(cell42);

                document.Add(newline);
                document.Add(table);

                // Hyper link
                Link link = new Link("click here",
                   PdfAction.CreateURI("https://www.google.com"));
                Paragraph hyperLink = new Paragraph("Please ")
                   .Add(link.SetBold().SetUnderline()
                   .SetItalic().SetFontColor(ColorConstants.BLUE))
                   .Add(" to go www.google.com.");

                document.Add(newline);
                document.Add(hyperLink);

                // Page numbers
                int n = pdf.GetNumberOfPages();
                for (int i = 1; i <= n; i++)
                {
                    document.ShowTextAligned(new Paragraph(String
                       .Format("page" + i + " of " + n)),
                       559, 806, i, TextAlignment.RIGHT,
                       VerticalAlignment.TOP, 0);
                }

                // Close document

            }
        }
}
