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
using orderingProduct.model;
using orderingProduct.services;

namespace orderingProduct
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
            context.Orders.Load();
            context.OrderDetails.Load();
            this.productBindingSource.DataSource = context.Products.Local.ToBindingList();
            this.customerBindingSource.DataSource = context.Customers.Local.ToBindingList();
            this.orderBindingSource.DataSource = context.Orders.Local.ToBindingList();
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
            this.panel1.Visible = !this.panel1.Visible;
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

        private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }

    
        private void AddOrder_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            
            order.OrderDate = this.orderDateBox.Value;
            order.CompanyName = this.comboBox1.SelectedValue.ToString();


            foreach ( DataGridViewRow r in this.dataGridView1.Rows)
            {
                OrderDetails o = new OrderDetails();
                Boolean toAdd=false;
                

                foreach (DataGridViewCell c in r.Cells)
                {
                    if (c.Value != null)
                    {
                        toAdd = true;
                        if (c.OwningColumn.Name.Equals("ProductId"))
                        {
                            o.ProductId = context.Products.Where(p => p.ProductId == (int)c.Value).First();
                        }
                        else o.Units = int.Parse(c.Value.ToString());

                    }
                    
                }
                if (toAdd)
                    order.OrdersDetails.Add(o);
                toAdd = false;
                

            }

            var errors  = OrderService.validOrder(order, context);

            if (errors.Count() == 0)
            {
                addNewOrder(order);
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                foreach (string s in errors)
                {
                    sb.Append(s);
                    sb.Append("\n");
                }
                MessageBox.Show(sb.ToString(), "Brak Towaru", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

                
        }

        private void addNewOrder(Order order)
        {
            foreach(OrderDetails od in order.OrdersDetails)
            {
                var prod = context.Products.Where(p => p.ProductId == od.ProductId.ProductId).First();
                prod.UnitsInStock -= od.Units;

            }
            context.Orders.Add(order);
            context.SaveChanges();
            this.dataGridView1.Rows.Clear();
            this.ordersDataGridView.Refresh();
          

        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            this.panel1.Visible = false;
        }


        private void wygenerujFakturęToolStripMenuItem1_Click(object sender, EventArgs e)
        {
     
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Order order = (Order) this.orderDataGridView.CurrentRow.DataBoundItem;
        }

        private void orderDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Order order = ((Order)this.orderDataGridView.CurrentRow.DataBoundItem);
            List<OrderBillDto> orBill = OrderService.findOrderBillDtosByOrder(order);
           
            this.customerName.Text = order.CompanyName;
            this.orderDate.Text = order.OrderDate.ToString();
            this.adressLabel.Text = context.Customers.Where(c => c.CompanyName == order.CompanyName).First().Adress;
            this.orderBillDtoBindingSource.DataSource = orBill;
            decimal sum = OrderService.findSumForOrderBill(orBill);

            this.sumLabel.Text = string.Format("{0}", sum);
            this.billPanel.Visible = true;
        }
    

        private void orderEdit_Click(object sender, EventArgs e)
        {
            var form = new EditOrderForm();
            Order order = ((Order)this.orderDataGridView.CurrentRow.DataBoundItem);
            form.OrderId = order.OrderId;
            form.ShowDialog();
        }

        private void ordersTab_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ProductService.supplyNewProducts(context, ((Product)productsDataGridView.CurrentRow.DataBoundItem).ProductId, (int) numericUpDown1.Value);
        }

    }
}
