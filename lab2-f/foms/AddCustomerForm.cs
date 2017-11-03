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
    public partial class AddCustomerForm : Form
    {
        ProductContext context;
        public AddCustomerForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            context = new ProductContext();

            base.OnLoad(e);
            context.Customers.Load();
            this.customerBindingSource.DataSource = context.Customers.Local.ToBindingList();
        }

        private void customerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }
    }
}
