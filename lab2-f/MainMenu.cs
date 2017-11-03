using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2_f
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
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
    }
}
