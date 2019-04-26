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
        public int flag { get; set; }


       

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
    [DataContract]
    public class RestaurantData
    {
        public RestaurantData()
        {
            this.RestaurantsTable = new DataTable("RestaurantsData");

        }

        [DataMember]
        public DataTable RestaurantsTable { get; set; }
    }
}
