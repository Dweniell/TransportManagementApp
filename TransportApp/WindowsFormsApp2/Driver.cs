using System;
using WindowsFormsApp2;

[Serializable]
public class Driver

{
    #region properties
    public static int counter {  get; set; }
    public int id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string age { get; set; }

    public Transport transporting { get; set; }

    #endregion
    public Driver() { 
    
    }
    public Driver(string first_name, string last_name, string age)
    {
     id = counter++;
        FirstName = first_name;
        LastName = last_name;
        this.age = age;
        transporting= new Transport();
        
    }



}


