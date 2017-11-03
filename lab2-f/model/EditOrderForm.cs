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

namespace lab2_f.model
{
    public partial class EditOrderForm : Form
    {
        ProductContext context;

        public int OrderId { get; set; }

        public EditOrderForm()
        {

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            context = new ProductContext();
            this.orderBindingSource.DataSource = getOrdersDetailsForId(OrderId);

        }

        private List<OrderDetails> getOrdersDetailsForId(int OrderId)
        {
            var ods = from o in context.OrderDetails where o.OrderId == this.OrderId select (o);
            return ods.ToList();

        }

        

        private void save_Click(object sender, EventArgs e)
        {
            context.SaveChanges();

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            context.Dispose();
            this.Close();
           
        }

        private void EditOrderForm_Load(object sender, EventArgs e)
        {

        }
    }
}
