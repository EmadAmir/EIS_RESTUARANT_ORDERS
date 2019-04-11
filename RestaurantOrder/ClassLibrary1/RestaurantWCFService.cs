﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace RestaurantWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RestaurantServiceWCF" in both code and config file together.
    public class RestaurantService : IRestaurantWCFService
    {
      
        //public string GetMessage(string name)
        //{
        //    return "Hello " + name;
        //}
        public void SaveDetails(Restaurant restaurant)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spSaveRestaurantCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterName = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = restaurant.Name
                };
                cmd.Parameters.Add(parameterName);
                SqlParameter parameterGender = new SqlParameter
                {
                    ParameterName = "@Gender",
                    Value = restaurant.Gender
                };
                cmd.Parameters.Add(parameterGender);
                SqlParameter parameterDateOfBirth = new SqlParameter
                {
                    ParameterName = "@DateOfBirth",
                    Value = restaurant.DateOfBirth
                };
                cmd.Parameters.Add(parameterDateOfBirth);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            
        }
    }
}