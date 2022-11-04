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

        public DeleteWindow(object selectedItem)
        {
            InitializeComponent();
            _product = selectedItem as Product;
            FillTextBoxes();
        }

        private void FillTextBoxes()
        {
            PId.Text = _product.product_id.ToString();
        }

        private void PAddBtn_Click(object sender, RoutedEventArgs e)
        {
            int num;
            bool isNum1 = Int32.TryParse(PId.Text, out num);

            if (isNum1)
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
            else
            {
                MessageBox.Show("Ошибка ввода");
            }
            this.Close();
        }
    }
}
