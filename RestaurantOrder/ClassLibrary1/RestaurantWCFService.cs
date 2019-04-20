using System;
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
        public RestaurantData GetMenu()

        {
            using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-75OND6D\EMADSQL;Initial Catalog=RestaurantDetails; User Id = sa ; Password= 123456"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT MenuID, DishName, DishCost FROM tblRestaurantMenu", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            RestaurantData restaurant = new RestaurantData();
                            sda.Fill(restaurant.RestaurantsTable);
                            return restaurant;
                        }

                    }
                }
            }
        }


        //public string GetMessage(string name)
        //{
        //    return "Hello " + name;
        //}
        public void SaveDetails(Restaurant restaurant)
        {
            //string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-75OND6D\EMADSQL;Initial Catalog=RestaurantDetails; User Id = sa ; Password= 123456"))
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
                SqlParameter parameterNum = new SqlParameter
                {
                    ParameterName = "@ContactNumber",
                    Value = restaurant.ContactNumber
                };
                cmd.Parameters.Add(parameterNum);
                SqlParameter parameterPassword = new SqlParameter
                {
                    ParameterName = "Password",
                    Value = restaurant.P_assword
                };
                cmd.Parameters.Add(parameterPassword);
                con.Open();
                cmd.ExecuteNonQuery();
            }


        }

        public Restaurant Login()
        {
            
            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-75OND6D\EMADSQL;Initial Catalog=RestaurantDetails; User Id = sa ; Password= 123456");

            SqlCommand cmd = new SqlCommand("spLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlpName = new SqlParameter();
            //sqlpName.ParameterName = "@Name";
            //sqlpName.Value = rest.CustomerName;
            //SqlParameter sqlpContact = new SqlParameter();
            //cmd.Parameters.Add(sqlpContact);
            //sqlpContact.ParameterName = "@Number";
            //sqlpContact.Value = rest.ContactNumber;
            //cmd.Parameters.Add(sqlpName);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    rest.Name = reader["CustomerName"].ToString();
            //    rest.ContactNumber = Convert.ToInt32(reader["ContactNumber"]);
            //}
            //return rest;
            Restaurant re = new Restaurant();
            if (reader.HasRows == true)
            {
                re.Flag = 1;
            }
            return re;
        }


    }
}
