using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class AddRouteForm : Form
    {
        
        public AddRouteForm()
        {
            InitializeComponent();
           
        }

        public Route GetNewRoute()
        {
            string routeName = textBox1.Text;
            Route newRoute = new Route { Name = routeName };
            return newRoute;
        }
        private void button1_Click(object sender, EventArgs e)
        {

           DialogResult = DialogResult.OK;
            
            

        }
    }
}
