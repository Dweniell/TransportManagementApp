using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class EditDriverForm : Form
    {
        private Driver driver;
        List<Transport> transports;
        public EditDriverForm(Driver driverer,List<Transport>transports)
        {
            InitializeComponent();
            this.driver = driverer;
            this.transports = transports;
            

        }

        private void button1add_Click(object sender, EventArgs e)
        {
            driver.LastName = LastNameTextBox.Text;
            driver.FirstName = FirstNameTextBox.Text;
            driver.age = AgeTextBox.Text;
            int id = int.Parse(ShipmentIdTextBox.Text);
            foreach (Transport t in transports)
            {

                if (t.id ==id)
                {
                    driver.transporting = t;
                }
               
            }

        }

        private void EditForm_Load_1(object sender, EventArgs e)
        {

           LastNameTextBox.Text = driver.LastName;
           FirstNameTextBox.Text = driver.FirstName;
           AgeTextBox.Text = driver.age;
           ShipmentIdTextBox.Text = driver.transporting.id.ToString();

        }
    }
}
