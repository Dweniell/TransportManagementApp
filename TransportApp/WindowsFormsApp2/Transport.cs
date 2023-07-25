using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    [Serializable]
    public class Transport
       
    {
        public static int counter { get; set; }
        public int id { get; set; }
        public string shipment { get; set; }

        public string CompanyName { get; set; }
        public int weight { get; set; }

        public Transport() {
        
        
        }
        public Transport(string name,string shipment,int weight )
        {
            id =counter++;
            this.CompanyName = name;
            this.shipment = shipment;
            this.weight = weight;
            
        }

        
    }
}
