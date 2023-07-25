using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace WindowsFormsApp2
{
    public partial class MainForm : Form
    {
       public List<Route> routes = new List<Route>();
        public List<Transport> transports = new List<Transport>();
        Route route=new Route("East");
        Route route2 = new Route("North");
        Transport Empty = new Transport("null","null",0);
        Transport transport1=new Transport("CocaCola","Sugar",15);
        Transport transport2 = new Transport("CompanyX", "Milk", 20);
        Route currentroute;
        public MainForm()
        {
            InitializeComponent();
            Driver newDriver = new Driver("John", "Doe", "34");
            Driver newDriver2 = new Driver("Mihai", "Petrescu", "35");
            Driver newDriver3 = new Driver("Mario", "Sandulescu", "30");
            newDriver.transporting = transport1;
            newDriver2.transporting = transport2;
            newDriver3.transporting = transport1;
            route.list.Add(newDriver);
            route2.list.Add(newDriver2);
            routes.Add(route);
            routes.Add(route2);
            transports.Add(Empty);
            transports.Add(transport1);
            transports.Add(transport2);

            //foreach (Route r in routes)
            //{

            //    RoutesComboBox.Items.Add(r);

            //}
            RoutesComboBox.DataSource = routes;
            RoutesComboBox.DisplayMember = "Name";
            Route selectedRoute = RoutesComboBox.SelectedItem as Route;
            currentroute = selectedRoute;
            
           
        }


        private void DisplayDrivers()
        {
            dgv.Rows.Clear();
            if (currentroute != null)
            { 
                foreach (Driver driver in currentroute.list)
                {
                    int rowId = dgv.Rows.Add(new object[]
                    {
                    driver.id,
                    driver.FirstName,
                    driver.LastName,
                    driver.age,
                    driver.transporting.shipment,
                    driver.transporting.CompanyName,
                    driver.transporting.weight

                    });

                    dgv.Rows[rowId].Tag = driver;

                }
            }
        }
        private void DisplayTransport()
        {
           dataGridView1.Rows.Clear();
            if (transports != null)
            {
                foreach (Transport transport in transports)
                {
                    int rowId = dataGridView1.Rows.Add(new object[]
                    {
                        transport.id,
                        transport.CompanyName,
                        transport.shipment,
                        transport.weight

                    });

                    dataGridView1.Rows[rowId].Tag = transport;

                }
            }
        }
        private void RefreshComboBox()
        {
            RoutesComboBox.DataSource = null;
            RoutesComboBox.DataSource = routes;
            RoutesComboBox.DisplayMember = "Name";
        }

       
        private void RoutesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Route j = RoutesComboBox.SelectedItem as Route;
            
            currentroute =j;
         
            DisplayDrivers();
            
           
        }



        private void button1_Add(object sender, EventArgs e)
        {
            AddDriverForm form = new AddDriverForm(currentroute);
            form.ShowDialog();
            if(form.DialogResult == DialogResult.OK)
            {
                Driver soferdecursalunga = form.getDriver();
                currentroute.list.Add(soferdecursalunga);
                DisplayDrivers();
               
            }

        }


        private void button2_Edit(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Choose a driver(click on the row before id to select)");
                return;
            }
            DataGridViewRow s = dgv.SelectedRows[0];
            Driver w = (Driver)s.Tag;
            EditDriverForm form2 = new EditDriverForm(w,transports);
            RoutesComboBox.DisplayMember=route.Name;
            RoutesComboBox.DataSource = routes;
            if (form2.ShowDialog() == DialogResult.OK)
            {
               DisplayDrivers();
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Choose a driver(click on the row before id to select)");
                return;
            }
            if (MessageBox.Show("Are you sure","Delete Driver",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataGridViewRow s = dgv.SelectedRows[0];
                Driver w = (Driver)s.Tag;
                currentroute.list.Remove(w);
                
                DisplayDrivers();
            }


        }

        

        private void csvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Route>));

            using (FileStream stream = File.Create("SerializedXML.xml"))
                serializer.Serialize(stream, routes);
            RefreshComboBox();
        }

        private void csvToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Route>));

            using (FileStream stream = File.OpenRead("SerializedXML.xml"))
            {
                routes = (List<Route>)serializer.Deserialize(stream);
             
            }
            DisplayDrivers();
            RefreshComboBox();
        }

        

        private void MainForm_Load(object sender, EventArgs e)
        {
           DisplayDrivers();
           DisplayTransport();
           
        }

        private void binaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = File.Create("serialized.bin"))
                    formatter.Serialize(stream, routes);
            
        }

        private void binaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.OpenRead("serialized.bin"))
               routes = (List<Route>)formatter.Deserialize(stream);
            RefreshComboBox();
            DisplayDrivers();
        }

      
        private void button4_Click(object sender, EventArgs e)
        {
            AddRouteForm r = new AddRouteForm();
            r.ShowDialog();
            if(r.DialogResult == DialogResult.OK)
            {
                Route NewRoute = r.GetNewRoute();
                routes.Add(NewRoute);
               RefreshComboBox();
              

            }



        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(currentroute != null)
            {

                EditRouteForm r = new EditRouteForm(currentroute);
                r.ShowDialog();
               if( r.DialogResult == DialogResult.OK)
                {
                    

                    RefreshComboBox();


                }


            }
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(routes.Count == 1)
            {
                MessageBox.Show("The list of routes cannot be smaller than 1");
                return;
            }
           
                
                routes.Remove(currentroute);
                routes.Sort();
                currentroute= routes[0];
                RefreshComboBox() ;


            

        }

        private void button9_Click(object sender, EventArgs e)
        {
            

        }



        private void buttonAddTransport_Click(object sender, EventArgs e)
        {
            AddTransportForm r = new AddTransportForm();   
            r.ShowDialog();
          
            if(r.DialogResult == DialogResult.OK)
            {
                Transport s = r.GetTransport();
                transports.Add(s);
                DisplayTransport();

            }


        }

        private void buttonEditTransport_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {

                MessageBox.Show("choose a transport to edit");
                return;

            }

            DataGridViewRow selectedTransport = dataGridView1.SelectedRows[0];
            Transport transport = (Transport)selectedTransport.Tag;
            EditTransportForm r = new EditTransportForm(transport);

            r.ShowDialog();
            if(r.DialogResult == DialogResult.OK) {
               // DisplayDrivers();
                //RefreshTransport();
                DisplayTransport();

            }

        }

        private void buttonDeleteTransport_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows == null)
            {
                MessageBox.Show("select a transport");
                return;

            }

            if (MessageBox.Show("Are you sure", "Delete Driver", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && transports.Count != 1)
            {
                DataGridViewRow s = dataGridView1.SelectedRows[0];
                Transport g = (Transport)s.Tag;
                transports.Remove(g);
                DisplayTransport();


            }
            else 
            { 
                MessageBox.Show("the transport list cannot be smaller than 1");
                return;
            }


        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt Files|*.txt";
            saveFileDialog1.Title = "Save Txt File";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                    {
                        writer.WriteLine("The routes we have and their respective drivers");
                        // Serialize the data and write it to the CSV file
                        foreach (Route route in routes)
                        {
                            writer.WriteLine();
                            string separator = $"{route.Name}";
                            writer.WriteLine(separator);
                            writer.WriteLine();
                            foreach (Driver sus in route.list)
                            {

                                string line = $"{sus.id},{sus.FirstName},{sus.LastName},{sus.age},{sus.transporting.CompanyName},{sus.transporting.shipment},{sus.transporting.weight}";
                                writer.WriteLine(line);
                            }

                        }
                    }
                }
                catch (Exception ex)
                {


                }

            }
        }
   
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            
            

            //chart properties
            int chartWidth = panel1.Width;
            int chartHeight = panel1.Height;
            int columnCount = routes.Count; 
            int columnWidth = chartWidth / columnCount;
            int maxColumnHeight = chartHeight - 20;
            
            List<int> columnValues = new List<int>(routes.Count);
                foreach (Route route in routes)
            {
                columnValues.Add(route.list.Count);
            }
            int[] columnHeights = new int[columnCount];
            //  chart axes
            Pen axisPen = new Pen(Color.Black, 2);
            g.DrawLine(axisPen, 40, chartHeight - 20, 40, 20); 
            g.DrawLine(axisPen, 40, chartHeight - 20, chartWidth - 20, chartHeight - 20);
            Font nameFont = new Font("Times New Roman", 10);
            // columns
            SolidBrush columnBrush = new SolidBrush(Color.Blue);
            for (int i = 0; i < columnCount; i++)
            {
                columnHeights[i] = (int)(maxColumnHeight * ((double)columnValues[i]/(double)columnValues.Max()));
                if (columnValues[i] == 0) {
                    columnHeights[i] = 1;
                }
                
                int x = 40 + i * columnWidth + 10; 
                int y = chartHeight - 20 - columnHeights[i]; 
                g.FillRectangle(columnBrush, x, y, columnWidth-20, columnHeights[i]);

                string routeName = routes.ElementAt(i).Name;
                SizeF nameSize = g.MeasureString(routeName, nameFont);
                float nameX = x + (columnWidth - nameSize.Width) / 2;
                float nameY = chartHeight - 20 + 5;
                g.DrawString(routeName, nameFont, Brushes.Black, nameX, nameY);
            }

           
            axisPen.Dispose();
            columnBrush.Dispose();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F)
            {


                AddDriverForm form = new AddDriverForm(currentroute);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    Driver soferdecursalunga = form.getDriver();
                    currentroute.list.Add(soferdecursalunga);
                    DisplayDrivers();

                }
            }
        }
    }

    
    }

