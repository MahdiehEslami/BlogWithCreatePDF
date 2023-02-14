using BlogZamin.Core.Contract.Categories.Queries.GetAllCategory;
using BlogZamin.Core.Contract.Categories.Queries.GetCategoryById;
using BlogZamin.Core.Contract.Categories.Queries;
using Microsoft.AspNetCore.Mvc;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.EndPoints.Web.Controllers;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using PdfSharp.Pdf;

namespace BlogZamin.EndPoint.API.Controllers.Categories
{
    [Route("api/[controller]")]
    public class CategoryQueryController : BaseController
    {
        [HttpGet("GetCategoryList")]
        public async Task<IActionResult> GetCategoryList(GetAllCategoryQuery getAllCategory)
           => await Query<GetAllCategoryQuery, PagedData<CategoryQr>>(getAllCategory);

        [HttpGet("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(GetCategoryByIdQuery query)
         => await Query<GetCategoryByIdQuery, CategoryQr>(query);

        [HttpGet("GeneratePdf")]
        public async Task<IActionResult> GeneratePdf(string InvoiceNo)
        {
            #region CreateFile
            var document = new PdfDocument();
            GetCategoryByIdQuery query = new GetCategoryByIdQuery() { CategoryId = 2 };
            var header = GetCategoryById(query);

                string htmlcontent = "<div style='width:100%; text-align:center'>";
                htmlcontent += "<h2>Welcome to SupperApp Teams</h2>";

                if (header != null)
                {
                    htmlcontent += "<h2> Invoice No:" + "FishNo" + " & Invoice Date:" + "FishDate " + "</h2>";
                    htmlcontent += "<div>";
                }
                htmlcontent += "<table style ='width:100%; border: 1px solid #000'>";
                htmlcontent += "<thead style='font-weight:bold'>";
                htmlcontent += "<tr>";
                htmlcontent += "<td style='border:1px solid #000'> Product Code </td>";
                htmlcontent += "<td style='border:1px solid #000'> Description </td>";
                htmlcontent += "<td style='border:1px solid #000'>Qty</td>";
                htmlcontent += "<td style='border:1px solid #000'>Price</td >";
                htmlcontent += "<td style='border:1px solid #000'>Total</td>";
                htmlcontent += "</tr>";
                htmlcontent += "</thead >";

                htmlcontent += "<tbody>";
                for (int j = 1; j < 10; j++)
                {
                    htmlcontent += "<tr>";
                    htmlcontent += "<td style='border:1px solid #000'>" + "procuct"+j + "</td>";
                    htmlcontent += "<td style='border:1px solid #000'>" + "ProductName"+j + "</td>";
                    htmlcontent += "<td style='border:1px solid #000'>" + "Qty"+j + "</td >";
                    htmlcontent += "<td style='border:1px solid #000'>" + "SalesPrice"+j + "</td>";
                    htmlcontent += "<td style='border:1px solid #000'> " + "Total"+j + "</td >";
                    htmlcontent += "</tr>";
                }
                //if (detail != null && detail.Count > 0)
                //{
                //    detail.ForEach(item =>
                //    {
                //        htmlcontent += "<tr>";
                //        htmlcontent += "<td>" + item.ProductCode + "</td>";
                //        htmlcontent += "<td>" + item.ProductName + "</td>";
                //        htmlcontent += "<td>" + item.Qty + "</td >";
                //        htmlcontent += "<td>" + item.SalesPrice + "</td>";
                //        htmlcontent += "<td> " + item.Total + "</td >";
                //        htmlcontent += "</tr>";
                //    });
                //}
                htmlcontent += "</tbody>";

                htmlcontent += "</table>";
                htmlcontent += "</div>";

                htmlcontent += "<div style='text-align:right'>";
                htmlcontent += "<h1> Summary Info </h1>";
                htmlcontent += "<table style='border:1px solid #000;float:right' >";
                htmlcontent += "<tr>";
                htmlcontent += "<td style='border:1px solid #000'> Summary Total </td>";
                htmlcontent += "<td style='border:1px solid #000'> Summary Tax </td>";
                htmlcontent += "<td style='border:1px solid #000'> Summary NetTotal </td>";
                htmlcontent += "</tr>";
                if (header != null)
                {
                    htmlcontent += "<tr>";
                    htmlcontent += "<td style='border: 1px solid #000'> " + "Total" + " </td>";
                    htmlcontent += "<td style='border: 1px solid #000'>" + "Tax" + "</td>";
                    htmlcontent += "<td style='border: 1px solid #000'> " + "NetTotal" + "</td>";
                    htmlcontent += "</tr>";
                }
                htmlcontent += "</table>";
                htmlcontent += "</div>";

                htmlcontent += "</div>";
            
                PdfGenerator.AddPdfPages(document, htmlcontent, PdfSharp.PageSize.A5);
            
            byte[]? response = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    document.Save(ms);
                    response = ms.ToArray();
                }
                string Filename = InvoiceNo + ".pdf";
          return File(response, "application/pdf",Filename);
            #endregion
        }


        #region Anothther way to Generate PDF
        //[HttpGet("GetPDFFileTable")]
        //public async Task<IActionResult> GetPdfFileTable()
        //{
        //    //Generate a new PDF document.
        //    PdfDocument doc = new PdfDocument();
        //    doc.PageSettings.Orientation = PdfPageOrientation.Landscape;
        //    doc.PageSettings.Margins.All = 50;
        //    //Add a page.
        //    PdfPage page = doc.Pages.Add();
        //    //Create a PdfGrid.
        //    PdfGrid pdfGrid = new PdfGrid();
        //    //Adding grid style
        //    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
        //    PdfGridStyle gridStyle = new PdfGridStyle();
        //    //Allow grid to overflow horizontally
        //    //gridStyle.AllowHorizontalOverflow = true;
        //    gridStyle.Font= font;
        //    //Adding cell spacing between cells
        //    gridStyle.CellSpacing = 3F;
        //    //Setting text pen for grid
        //    gridStyle.TextBrush = PdfBrushes.Black;
        //    //Applying style to grid
        //    pdfGrid.Style = gridStyle;
        //    //Add values to list.
        //    //var result = Query<GetCategoryByIdQuery, CategoryQr>(query);
        //    List<object> data = new List<object>();
        //    for (int i = 0; i < 20; i++)
        //    {
        //        Object row = new { ID = i, Name = "Clay" + i, family = "sally" + i, sallary = 2500 * i };
        //        data.Add(row);
        //    }
        //    //Add list to IEnumerable.
        //    IEnumerable<object> dataTable = data;
        //    //Assign data source.
        //    pdfGrid.DataSource = dataTable;
        //    //Draw grid to the page of PDF document.
        //    pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 10));
        //    //Write the PDF document to stream.
        //    MemoryStream stream = new MemoryStream();
        //    doc.Save(stream);
        //    //If the position is not set to '0' then the PDF will be empty.
        //    stream.Position = 0;
        //    //Close the document.
        //    doc.Close(true);
        //    //Creates a FileContentResult object by using the file contents, content type, and file name.
        //    FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
        //    fileStreamResult.FileDownloadName = "Sample.pdf";
        //    return fileStreamResult;
        //    //return File(stream, contentType, fileName).FileStream;
        //}

        //[HttpGet("CreateDocument")]
        //public ActionResult CreateDocument()
        //{

        //    //Create a new PDF document
        //    PdfDocument document = new PdfDocument();

        //    //Add a page to the document
        //    PdfPage page = document.Pages.Add();

        //    //Create PDF graphics for the page
        //    PdfGraphics graphics = page.Graphics;

        //    //Set the standard font
        //    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

        //    //Draw the text
        //    graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));

        //    //Saving the PDF to the MemoryStream
        //    MemoryStream stream = new MemoryStream();

        //    document.Save(stream);

        //    //If the position is not set to '0' then the PDF will be empty.
        //    stream.Position = 0;

        //    //Download the PDF document in the browser.
        //    FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
        //    fileStreamResult.FileDownloadName = "Output.pdf";
        //    return fileStreamResult;

        //}

        //[HttpGet("GetPDFFile")]
        //public FileResult GetPDFFile(GetAllCategoryQuery getAllCategory)
        //{
        //    // create a unique file name
        //    string fileName = Guid.NewGuid() + ".pdf";

        //    var result = Query<GetAllCategoryQuery, PagedData<CategoryQr>>(getAllCategory);
        //    // convert HTML text to stream
        //    byte[] byteArray = Encoding.UTF8.GetBytes(result.Id.ToString());

        //    // generate PDF from the HTML
        //    MemoryStream stream = new MemoryStream(byteArray);
        //    HtmlLoadOptions options = new HtmlLoadOptions();
        //    Document pdfDocument = new Document(stream, options);

        //    // create memory stream for the PDF file
        //    Stream outputStream = new MemoryStream();
        //    pdfDocument.Save(outputStream);

        //    // return generated PDF file
        //    return File(outputStream, System.Net.Mime.MediaTypeNames.Application.Pdf, fileName);
        //}

        //[HttpGet("GetPDFFileTablee")]
        //public FileResult GetPdfFileTablee(GetCategoryByIdQuery query)
        //{
        //    //Generate a new PDF document.
        //    PdfDocument doc = new PdfDocument();
        //    //Add a page.
        //    PdfPage page = doc.Pages.Add();
        //    //Create a PdfGrid.
        //    PdfGrid pdfGrid = new PdfGrid();
        //    //Add values to list.
        //    var result = Query<GetCategoryByIdQuery, CategoryQr>(query);
        //    List<object> data = new List<object>();
        //    for (int i = 0; i < 20; i++)
        //    {
        //        Object row = new { ID = i, Name = "Clay" + i };
        //        data.Add(row);
        //    }
        //    //Add list to IEnumerable.
        //    IEnumerable<object> dataTable = data;
        //    //Assign data source.
        //    pdfGrid.DataSource = dataTable;
        //    //Draw grid to the page of PDF document.
        //    pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 10));
        //    //Write the PDF document to stream.
        //    MemoryStream stream = new MemoryStream();
        //    doc.Save(stream);
        //    //If the position is not set to '0' then the PDF will be empty.
        //    stream.Position = 0;
        //    //Close the document.
        //    doc.Close(true);
        //    //Defining the ContentType for pdf file.
        //    string contentType = "application/pdf";
        //    //Define the file name.
        //    string fileName = "Output.pdf";
        //    //Creates a FileContentResult object by using the file contents, content type, and file name.
        //    return File(stream, contentType, fileName);
        //}

        //[HttpGet("GetPDFFileTableNew")]
        //public async Task<FileStreamResult> GetPDFFileTableNew()
        //{
        //    //Create a new PDF document
        //    PdfDocument pdfDocument = new PdfDocument();
        //    //Add a page to the document 
        //    PdfPage pdfPage = pdfDocument.Pages.Add();
        //    //Create a new PdfGrid
        //    PdfGrid pdfGrid = new PdfGrid();
        //    //Add three columns
        //    pdfGrid.Columns.Add(3);
        //    //Add header
        //    pdfGrid.Headers.Add(1);
        //    PdfGridRow pdfGridHeader = pdfGrid.Headers[0];
        //    pdfGridHeader.Cells[0].Value = "Employee ID";
        //    pdfGridHeader.Cells[1].Value = "Employee Name";
        //    pdfGridHeader.Cells[2].Value = "Salary";
        //    //Add style to header
        //    pdfGridHeader.Style.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 15, PdfFontStyle.Bold);
        //    //Add rows
        //    PdfGridRow pdfGridRow = pdfGrid.Rows.Add();
        //    pdfGridRow.Cells[0].Value = "E01";
        //    pdfGridRow.Cells[1].Value = "Clay";
        //    pdfGridRow.Cells[2].Value = "$10,000";
        //    pdfGridRow.Height = 50;
        //    //Specify the style for the PdfGridCell
        //    PdfGridCellStyle pdfGridCellStyle = new PdfGridCellStyle();
        //    pdfGridCellStyle.TextPen = PdfPens.Red;
        //    pdfGridCellStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
        //    PdfGridCell pdfGridCell = pdfGrid.Rows[0].Cells[0];
        //    //Apply style
        //    pdfGridCell.Style = pdfGridCellStyle;
        //    //Set image position for the background image in the style
        //    pdfGridCell.ImagePosition = PdfGridImagePosition.Stretch;
        //    //Draw the PdfGrid
        //    pdfGrid.Draw(pdfPage, new Syncfusion.Drawing.PointF(10, 10));
        //    //Save the document
        //    MemoryStream stream = new MemoryStream();
        //    pdfDocument.Save(stream);
        //    //Close the document
        //    pdfDocument.Close(true);
        //    stream.Position = 0;
        //    //This will open the PDF file so, the result will be seen in default PDF Viewer 
        //    //System.Diagnostics.Process.Start("Table.pdf");
        //    //Defining the ContentType for pdf file.
        //    string contentType = "application/pdf";
        //    //Define the file name.
        //    string fileName = "Output.pdf";
        //    //Creates a FileContentResult object by using the file contents, content type, and file name.
        //    FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
        //    fileStreamResult.FileDownloadName = "Sample.pdf";
        //    return fileStreamResult;
        //    //return File(stream, contentType, fileName).FileStream;
        //}
        ////public async Task<FileStreamResult> GetPDFFileTableNew()
        ////{
        ////    //Create a new PDF document.
        ////    PdfDocument document = new PdfDocument();
        ////    document.PageSettings.Orientation = PdfPageOrientation.Landscape;
        ////    document.PageSettings.Margins.All = 50;

        ////    //Add a page to the document.
        ////    PdfPage page = document.Pages.Add();

        ////    //Create PDF graphics for the page.
        ////    PdfGraphics graphics = page.Graphics;

        ////    //Create a text element with the text and font.
        ////    PdfTextElement element = new PdfTextElement("Northwind Traders\n67, rue des Cinquante Otages,\nElgin,\nUnites States.");
        ////    element.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
        ////    element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
        ////    PdfLayoutResult result = element.Draw(page, new RectangleF(0, 0, page.Graphics.ClientSize.Width / 2, 200));

        ////    //Draw the image to PDF page with specified size. 
        ////    //FileStream imageStream = new FileStream("", FileMode.Open, FileAccess.Read);
        ////    PdfImage img = new PdfBitmap(new FileStream.Empty());

        ////    graphics.DrawImage(img, new RectangleF(graphics.ClientSize.Width - 200, result.Bounds.Y, 190, 45));
        ////    PdfFont subHeadingFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
        ////    graphics.DrawRectangle(new PdfSolidBrush(new PdfColor(126, 151, 173)), new RectangleF(0, result.Bounds.Bottom + 40, graphics.ClientSize.Width, 30));

        ////    //Create a text element with the text and font.
        ////    element = new PdfTextElement("INVOICE", subHeadingFont);
        ////    element.Brush = PdfBrushes.White;
        ////    result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 48));
        ////    string currentDate = "DATE " + DateTime.Now.ToString("MM/dd/yyyy");
        ////    SizeF textSize = subHeadingFont.MeasureString(currentDate);
        ////    graphics.DrawString(currentDate, subHeadingFont, element.Brush, new PointF(graphics.ClientSize.Width - textSize.Width - 10, result.Bounds.Y));

        ////    //Create a text element and draw it to PDF page.
        ////    element = new PdfTextElement("BILL TO ", new PdfStandardFont(PdfFontFamily.TimesRoman, 10));
        ////    element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
        ////    result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 25));
        ////    graphics.DrawLine(new PdfPen(new PdfColor(126, 151, 173), 0.70f), new PointF(0, result.Bounds.Bottom + 3), new PointF(graphics.ClientSize.Width, result.Bounds.Bottom + 3));

        ////    //FileStream xmlStream = new FileStream("", FileMode.Open, FileAccess.Read);

        ////    //Get products list to create invoice. 
        ////    List<object> data = new List<object>();
        ////    for (int i = 0; i < 20; i++)
        ////    {
        ////        Object row = new { ID = i, Name = "Clay" + i };
        ////        data.Add(row);
        ////    }

        ////    //FileStream shipStream = new FileStream("", FileMode.Open, FileAccess.Read);

        ////    //Get the shipping address details. 
        ////    //IEnumerable<ShipDetails> shipDetails = Orders.GetShipDetails(shipStream);
        ////    //GetShipDetails(shipDetails);

        ////    //Create a text element and draw it to PDF page.
        ////    element = new PdfTextElement("shipCity", new PdfStandardFont(PdfFontFamily.TimesRoman, 10));
        ////    element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
        ////    result = element.Draw(page, new RectangleF(10, result.Bounds.Bottom + 5, graphics.ClientSize.Width / 2, 100));

        ////    //Create a text element and draw it to PDF page.
        ////    element = new PdfTextElement(string.Format("{0}, {1}, {2}", "address", "shipCity", "shipCountry"), new PdfStandardFont(PdfFontFamily.TimesRoman, 10));
        ////    element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
        ////    result = element.Draw(page, new RectangleF(10, result.Bounds.Bottom + 3, graphics.ClientSize.Width / 2, 100));

        ////    //Create a PDF grid with product details.
        ////    PdfGrid grid = new PdfGrid();
        ////    grid.DataSource = data;

        ////    //Initialize PdfGridCellStyle and set border color.
        ////    PdfGridCellStyle cellStyle = new PdfGridCellStyle();
        ////    cellStyle.Borders.All = PdfPens.White;
        ////    cellStyle.Borders.Bottom = new PdfPen(new PdfColor(217, 217, 217), 0.70f);
        ////    cellStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12f);
        ////    cellStyle.TextBrush = new PdfSolidBrush(new PdfColor(131, 130, 136));

        ////    //Initialize PdfGridCellStyle and set header style.
        ////    PdfGridCellStyle headerStyle = new PdfGridCellStyle();
        ////    headerStyle.Borders.All = new PdfPen(new PdfColor(126, 151, 173));
        ////    headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
        ////    headerStyle.TextBrush = PdfBrushes.White;
        ////    headerStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14f, PdfFontStyle.Regular);

        ////    PdfGridRow header = grid.Headers[0];
        ////    for (int i = 0; i < header.Cells.Count; i++)
        ////    {
        ////        if (i == 0 || i == 1)
        ////            header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
        ////        else
        ////            header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
        ////    }
        ////    header.ApplyStyle(headerStyle);

        ////    foreach (PdfGridRow row in grid.Rows)
        ////    {
        ////        row.ApplyStyle(cellStyle);
        ////        for (int i = 0; i < row.Cells.Count; i++)
        ////        {
        ////            //Create and customize the string formats
        ////            PdfGridCell cell = row.Cells[i];
        ////            if (i == 1)
        ////                cell.StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
        ////            else if (i == 0)
        ////                cell.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
        ////            else
        ////                cell.StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);

        ////            if (i > 2)
        ////            {
        ////                float val = float.MinValue;
        ////                float.TryParse(cell.Value.ToString(), out val);
        ////                cell.Value = '$' + val.ToString("0.00");
        ////            }
        ////        }
        ////    }

        ////    grid.Columns[0].Width = 100;
        ////    grid.Columns[1].Width = 200;

        ////    //Set properties to paginate the grid.
        ////    PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
        ////    layoutFormat.Layout = PdfLayoutType.Paginate;

        ////    //Draw grid to the page of PDF document.
        ////    PdfGridLayoutResult gridResult = grid.Draw(page, new RectangleF(new PointF(0, result.Bounds.Bottom + 40), new SizeF(graphics.ClientSize.Width, graphics.ClientSize.Height - 100)), layoutFormat);
        ////    float pos = 0.0f;
        ////    for (int i = 0; i < grid.Columns.Count - 1; i++)
        ////        pos += grid.Columns[i].Width;

        ////    PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14f);

        ////    //GetTotalPrice(products);

        ////    gridResult.Page.Graphics.DrawString("Total Due", font, new PdfSolidBrush(new PdfColor(126, 151, 173)), new RectangleF(new PointF(pos, gridResult.Bounds.Bottom + 20), new SizeF(grid.Columns[3].Width - pos, 20)), new PdfStringFormat(PdfTextAlignment.Right));
        ////    gridResult.Page.Graphics.DrawString("Thank you for your business!", new PdfStandardFont(PdfFontFamily.TimesRoman, 12), new PdfSolidBrush(new PdfColor(89, 89, 93)), new PointF(pos - 55, gridResult.Bounds.Bottom + 60));
        ////    pos += grid.Columns[4].Width;
        ////    gridResult.Page.Graphics.DrawString('$' + string.Format("{0:N2}", 5), font, new PdfSolidBrush(new PdfColor(131, 130, 136)), new RectangleF(new PointF(pos, gridResult.Bounds.Bottom + 20), new SizeF(grid.Columns[4].Width - pos, 20)), new PdfStringFormat(PdfTextAlignment.Right));

        ////    //Saving the PDF to the MemoryStream/
        ////    MemoryStream stream = new MemoryStream();

        ////    document.Save(stream);

        ////    //Set the position as '0'.
        ////    stream.Position = 0;

        ////    //Download the PDF document in the browser.
        ////    FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");

        ////    fileStreamResult.FileDownloadName = "Sample.pdf";

        ////    return fileStreamResult;
        ////}
        #endregion

    }
}
