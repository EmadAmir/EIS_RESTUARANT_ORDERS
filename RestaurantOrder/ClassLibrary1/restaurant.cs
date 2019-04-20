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
        private long _contactNumber;
        private int _flag;
        private string _password;


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
        public long ContactNumber
        {
            get { return _contactNumber; }
            set { _contactNumber = value; }
        }
        public int Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
        public string P_assword
        {
            get { return _password; }
            set { _password = value; }
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
