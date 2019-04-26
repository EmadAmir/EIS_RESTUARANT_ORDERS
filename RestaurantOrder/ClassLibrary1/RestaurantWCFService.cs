using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;

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

        public void Login(Restaurant restaurant)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-75OND6D\EMADSQL;Initial Catalog=RestaurantDetails; User Id = sa ; Password= 123456"))
            {
                SqlCommand cmd;
                con.Open();
                string s = "select CustomerName,Password from tblCustomer where CustomerName ='"+restaurant.Name+"' and Password ='"+restaurant.Psw+"' ";
                cmd = new SqlCommand(s, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    restaurant.flag = 1;
                }
                else
                {
                    restaurant.flag = 0;
                }
                
                con.Close();

            }
        }

        public void SaveDetails(Restaurant r)
        {

            using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-75OND6D\EMADSQL;Initial Catalog=RestaurantDetails; User Id = sa ; Password= 123456"))
            {
                    SqlCommand cmd;
                    con.Open();
                    string s = "insert into tblCustomer values(@CustomerName,@CustomerGender,@Password)";
                    cmd = new SqlCommand(s, con);
                    cmd.Parameters.AddWithValue("@CustomerName",   r.Name );
                    cmd.Parameters.AddWithValue("@CustomerGender", r.Gender);
                    cmd.Parameters.AddWithValue("@Password", r.Psw);
              
                    cmd.CommandType = CommandType.Text;
                
                    cmd.ExecuteNonQuery();
                    con.Close();
                 
                }



            }


        }
    }


    

