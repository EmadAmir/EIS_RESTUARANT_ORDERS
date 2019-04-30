using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWCFService
{
    public class Restaurant
    {
        private string _Name;
        private string _gender;
        private DateTime _dateOfBirth;
       // private string _password;
        public string Psw { get; set; }
        public int F { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public string items { get; set; }
        public string DName { get; set; }
        public double DCost { get; set; }


       

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Gender
        {
            get { return _gender;}
            set { _gender = value; }
        }
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth;}
            set { _dateOfBirth = value; }
        }
       


    }
   
}
