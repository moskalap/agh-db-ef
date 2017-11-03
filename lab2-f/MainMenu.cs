using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace lab2_f
{
    public partial class MainMenu : Form
    {
        ProductContext context;
        public MainMenu()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            context = new ProductContext();

            base.OnLoad(e);
            context.Customers.Load();
            context.Products.Load();
            context.Categories.Load();
            this.customerBindingSource.DataSource = context.Customers.Local.ToBindingList();
            //this.productsBindingSource.DataSource = context.Products.Local.ToBindingList();
            this.categoryBindingSource.DataSource = context.Categories.Local.ToBindingList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new AddCustomerForm();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new OrderForm();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new CategoryForm();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form = new AddOrderForm();
            form.ShowDialog();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }

        private void customerBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
