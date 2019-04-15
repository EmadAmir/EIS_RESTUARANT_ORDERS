using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWCFService
{
    public class Restaurant
    {
        private string _name;
        private string _gender;
        private DateTime _dateOfBirth;
        private int _contactNumber;
        private string _menu;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
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
        public int ContactNumber
        {
            get { return _contactNumber; }
            set { _contactNumber = value; }
        }
        public string Menu
        {
            get { return _menu; }
            set { _menu = value; }
        }

    }
}
