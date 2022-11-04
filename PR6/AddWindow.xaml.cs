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
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void PAddBtn_Click(object sender, RoutedEventArgs e)
        {
            int num;
            bool isNum1 = Int32.TryParse(PPrice.Text, out num);
            bool isNum2 = Int32.TryParse(PFactory.Text, out num);

            if (isNum1 && isNum2)
            {
                using (PraktikaDBEntities db = new PraktikaDBEntities())
                {
                    Product r = new Product();
                    r.product_name = PName.Text;
                    r.product_price = int.Parse(PPrice.Text);
                    r.product_category = PCategory.Text;
                    r.factory_id = int.Parse(PFactory.Text);
                    db.Products.Add(r);
                    db.SaveChanges();
                }
            }
            else {
                MessageBox.Show("Ошибка ввода");
            }

            this.Close();

            MainWindow page = new MainWindow();
            page.Show();

        }
    }
}
