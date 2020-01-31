using iTextSharp.text;
using iTextSharp.text.pdf;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repotr
{
    public class CreateReport
    {
        public void createReport(String FileName, String Title, String[] ColumnNames, List<Obj> data)
        {
            //открываем файл для работы
            FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            //создаем документ, задаем границы, связываем документ и поток
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            doc.SetMargins(0.5f, 0.5f, 0.5f, 0.5f);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.WINANSI, BaseFont.NOT_EMBEDDED);
            //вставляем заголовок
            var phraseTitle = new Phrase(Title,
            new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD));
            iTextSharp.text.Paragraph paragraph = new
           iTextSharp.text.Paragraph(phraseTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };
            doc.Add(paragraph);
            //вставляем таблицу, задаем количество столбцов, и ширину колонок
            PdfPTable table = new PdfPTable(2)
            {
                TotalWidth = 800F
            };
            table.SetTotalWidth(new float[] { 160, 140});
            //вставляем шапку
            PdfPCell cell = new PdfPCell();
            var fontForCellBold = new iTextSharp.text.Font(baseFont, 10,
           iTextSharp.text.Font.BOLD);
            table.AddCell(new PdfPCell(new Phrase(ColumnNames[0], fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase(ColumnNames[1], fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            //заполняем таблицу
            var fontForCells = new iTextSharp.text.Font(baseFont, 10);
            for (int i = 0; i < data.Count; i++)
            {
                cell = new PdfPCell(new Phrase(data[i].Name, fontForCells));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(data[i].Enum, fontForCells));
                table.AddCell(cell);
            }
            //вставляем таблицу
            doc.Add(table);
            doc.Close();
        }
    }
}
