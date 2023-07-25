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
    public partial class AddDriverForm : Form
    {
        private Transport transport {  get; set; }  
        private Route route {get; set;}
        
        public AddDriverForm(Route route)
        {
            InitializeComponent();
            this.route = route;
        }

        private bool IsLastNameValid()
        {
            return string.IsNullOrWhiteSpace(LastNameTextBox.Text.Trim());
        }

        public Driver getDriver() {
           
                string FirstName = FirstNameTextBox.Text;
                string LastName = LastNameTextBox.Text;
                string age = ageTextBox.Text;

                var driver = new Driver(FirstName, LastName, age);
                return driver;
            
        }

        private void button1add_Click(object sender, EventArgs e)
        {
          

           DialogResult result = DialogResult.OK;

        }

        private void LastNameTextBox_Validated(object sender, EventArgs e)
        {
            
            
        }

        private void LastNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            string lastName = LastNameTextBox.Text;
            
            if (string.IsNullOrEmpty(lastName))
            {
               
                errorProviderAddWaiter.SetError(LastNameTextBox, "Last name is required.");
            }
            else
            {
                // Clear the error if the last name is not empty
                
                errorProviderAddWaiter.SetError(LastNameTextBox, string.Empty);

        
               
            }

        }

        private void AddDriverForm_Load(object sender, EventArgs e)
        {

        }

        private void FirstNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
