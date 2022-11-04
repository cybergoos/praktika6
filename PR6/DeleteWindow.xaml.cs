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
using System.Windows.Shapes;

namespace PR6
{
    /// <summary>
    /// Interaction logic for DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        private Product _product;
        private Factory _factory;

        string tableName;

        public DeleteWindow(object selectedItem, string table)
        {
            InitializeComponent();

            if (table == "product")
            {
                _product = selectedItem as Product;
                FillTextBoxes1();
                tableName = table;
            }

            if (table == "factory")
            {
                _factory = selectedItem as Factory;
                FillTextBoxes2();
                tableName = table;
            }
        }

        private void FillTextBoxes1()
        {
            PId.Text = _product.product_id.ToString();
        }

        private void FillTextBoxes2()
        {
            PId.Text = _factory.factory_id.ToString();
        }

        private void PAddBtn_Click(object sender, RoutedEventArgs e)
        {
            int num;
            bool isNum1 = Int32.TryParse(PId.Text, out num);

            if (isNum1)
            {
                if (tableName == "product")
                {
                    using (PraktikaDBEntities db = new PraktikaDBEntities())
                    {
                        Product r = new Product();
                        r = db.Products.Find(int.Parse(PId.Text));
                        if (r != null)
                        {
                            db.Products.Remove(r);

                            db.SaveChanges();
                        }
                    }
                }
                if (tableName == "factory")
                {
                    using (PraktikaDBEntities db = new PraktikaDBEntities())
                    {
                        Factory r = new Factory();
                        r = db.Factories.Find(int.Parse(PId.Text));
                        if (r != null)
                        {
                            db.Factories.Remove(r);

                            db.SaveChanges();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Ошибка ввода");
            }

            this.Close();

            MainWindow page = new MainWindow();
            page.Show();
        }
    }
}
