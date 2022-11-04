using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Word = Microsoft.Office.Interop.Word;

namespace PR6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Tables
            ProductTable.ItemsSource = PraktikaDBEntities.GetContext().Products.ToList();
            FactoryTable.ItemsSource = PraktikaDBEntities.GetContext().Factories.ToList();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ProductTable.SelectedItem != null)
            {
                DeleteWindow a = new DeleteWindow(ProductTable.SelectedItem);
                a.Show();
            }
            else
            {
                MessageBox.Show("Выберите строку");
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddWindow page = new AddWindow();
            page.Show();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ProductTable.SelectedItem != null)
            {
                UpdateWindow a = new UpdateWindow(ProductTable.SelectedItem);
                a.Show();
            }
            else
            {
                MessageBox.Show("Выберите строку");
            }
        }

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Product> products;
            List<Factory> factories;
            using (PraktikaDBEntities usersEntities = new PraktikaDBEntities())
            {
                products = usersEntities.Products.ToList().OrderBy(s => s.product_name).ToList();
                factories = usersEntities.Factories.ToList().OrderBy(g => g.factory_name).ToList();
                var app = new Word.Application();
                Word.Document document = app.Documents.Add();

                Word.Paragraph paragraph =
                document.Paragraphs.Add();
                Word.Range range = paragraph.Range;

                Word.Paragraph tableParagraph = document.Paragraphs.Add();
                Word.Range tableRange = tableParagraph.Range;
                Word.Table studentsTable =
                document.Tables.Add(tableRange, products.Count() + 1, 5);
                studentsTable.Borders.InsideLineStyle =
                studentsTable.Borders.OutsideLineStyle =
                Word.WdLineStyle.wdLineStyleSingle;
                studentsTable.Range.Cells.VerticalAlignment =
                Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                Word.Range cellRange;
                cellRange = studentsTable.Cell(1, 1).Range;
                cellRange.Text = "ИД";
                cellRange = studentsTable.Cell(1, 2).Range;
                cellRange.Text = "Название";
                cellRange = studentsTable.Cell(1, 3).Range;
                cellRange.Text = "Цена";
                cellRange = studentsTable.Cell(1, 4).Range;
                cellRange.Text = "Категория";
                cellRange = studentsTable.Cell(1, 5).Range;
                cellRange.Text = "Предприятие";
                studentsTable.Rows[1].Range.Bold = 1;
                studentsTable.Rows[1].Range.ParagraphFormat.Alignment =
                Word.WdParagraphAlignment.wdAlignParagraphCenter;
                int i = 1;
                foreach (var currentrep in products)
                {
                    cellRange = studentsTable.Cell(i + 1, 1).Range;
                    cellRange.Text = currentrep.product_id.ToString();
                    cellRange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = studentsTable.Cell(i + 1, 2).Range;
                    cellRange.Text = currentrep.product_name.ToString();
                    cellRange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = studentsTable.Cell(i + 1, 3).Range;
                    cellRange.Text = currentrep.product_price.ToString();
                    cellRange.ParagraphFormat.Alignment =
                     Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = studentsTable.Cell(i + 1, 4).Range;
                    cellRange.Text = currentrep.product_category.ToString();
                    cellRange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = studentsTable.Cell(i + 1, 5).Range;
                    cellRange.Text = currentrep.factory_id.ToString();
                    cellRange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    i++;
                }
                Word.Paragraph countStudentsParagraph = document.Paragraphs.Add();
                Word.Range countStudentsRange =
                countStudentsParagraph.Range;
                countStudentsRange.Text = $"Количество продуктов -{ products.Count()}";
                countStudentsRange.Font.Color = Word.WdColor.wdColorDarkRed;
                countStudentsRange.InsertParagraphAfter();
                document.Words.Last.InsertBreak(Word.WdBreakType.wdPageBreak);

                app.Visible = true;
                document.SaveAs2(@"D:\outputFileWord.docx");
                document.SaveAs2(@"D:\outputFilePdf.pdf",
                Word.WdExportFormat.wdExportFormatPDF);
            }
        }
    }
}
