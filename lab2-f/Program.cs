using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace orderingProduct
{
    class Program
    {
        static void Main(string[] args)
        {


            Thread thread = new Thread(() =>
            {
                var form = new MainMenu();
                form.ShowDialog();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            

        }
    }
}
