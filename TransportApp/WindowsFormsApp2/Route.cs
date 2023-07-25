using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    [Serializable]
    public class Route

    {
        public static int counter { get; set; }
        public int id { get; set; }
        public string Name { get; set; }

        public List<Driver> list { get; set; }

      public Route() { 
        Name= "wtf";
        this.list = new List<Driver>();
        }
        public Route(string name)
        {
            id = counter++;
            this.Name = name;
            list = new List<Driver>();
        }


    }
}
