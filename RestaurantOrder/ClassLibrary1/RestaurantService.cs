using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace RestaurantService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RestaurantServiceWCF" in both code and config file together.
    public class RestaurantService : IRestaurantServices
    {
      
        //public string GetMessage(string name)
        //{
        //    return "Hello " + name;
        //}
        public void SaveDetails(Restaurant Restaurant)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp")
            }
            
        }
    }
}
