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
    public partial class EditTransportForm : Form
    {
        Transport trans;
        public EditTransportForm(Transport transport)
        {
            InitializeComponent();
            this.trans=transport;

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            
            trans.shipment=textBoxShipment.Text;
            trans.CompanyName = textBoxCompany.Text;
            trans.weight=int.Parse(textBoxWeight.Text);
        }

        private void EditTransportForm_Load(object sender, EventArgs e)
        {
           
            textBoxShipment.Text = trans.shipment;
            textBoxCompany.Text = trans.CompanyName;
            textBoxWeight.Text = trans.weight.ToString();


        }
    }
}
