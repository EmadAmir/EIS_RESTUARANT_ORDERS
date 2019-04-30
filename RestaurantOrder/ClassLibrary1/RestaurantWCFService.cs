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
        public void GetMenu()

        {
            using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-75OND6D\EMADSQL;Initial Catalog=RestaurantDetails; User Id = sa ; Password= 123456"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT MenuID, DishName, DishCost FROM tblRestaurantMenu", con))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    List<string> MenuList = new List<string>();
                    foreach (DataRow row in dt.Rows)
                    {
                        MenuList.Add(row.ToString());
                    }
                     
                }
                }
            }

        public void insertmenu(Restaurant r)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-75OND6D\EMADSQL;Initial Catalog=RestaurantDetails; User Id = sa ; Password= 123456"))
            {
                SqlCommand cmd;
                con.Open();
                string s = "insert into tblRestaurantMenu values(@DishName,@DishCost)";
                cmd = new SqlCommand(s, con);
                cmd.Parameters.AddWithValue("@DishName", r.DName);
                cmd.Parameters.AddWithValue("@DishCost", r.DCost);
           

                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                con.Close();

            }
            //throw new NotImplementedException();
        }

        public int Login(Restaurant restaurant)
        {
            int flag = 0;
            using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-75OND6D\EMADSQL;Initial Catalog=RestaurantDetails; User Id = sa ; Password= 123456"))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select CustomerName,Password from tblCustomer where CustomerName = '"+restaurant.Name+ "' and Password = '" + restaurant.Psw + "'", con))
                {
                   // Console.WriteLine(restaurant.F);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //Console.WriteLine(restaurant.F);
                    if (dt.Rows.Count > 0)
                    {
                        return flag = 1;
                    }
                    else
                    {
                        return flag = 2;
                    }
                   
                }; 
            };
        }

            //    if (restaurant.Name == " ")
            //    {
            //        restaurant.somevalue = 0;
            //    }
            //    if (restaurant.Psw == " ")
            //    {
            //        restaurant.somevalue = 1;

            //    }
            //    try
            //    {
            //        SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-75OND6D\EMADSQL;Initial Catalog=RestaurantDetails; User Id = sa ; Password= 123456");
            //        SqlCommand myCommand = default(SqlCommand);
            //        myCommand = new SqlCommand("select CustomerName,Password from tblCustomer where CustomerName = @UserName and Password = @Password", con);
            //        SqlParameter uName = new SqlParameter("@UserName ", SqlDbType.VarChar);
            //        SqlParameter uPassword = new SqlParameter("@Password ", SqlDbType.VarChar);
            //        uName.Value = restaurant.Name;
            //        uPassword.Value = restaurant.Psw;
            //        myCommand.Parameters.Add(uName);
            //        myCommand.Parameters.Add(uPassword);
            //        myCommand.Connection.Open();
            //        SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            //        if (myReader.Read() == true)
            //        {
            //            restaurant.somevalue = 2;
            //        }
            //        else
            //        {
            //            restaurant.somevalue = 3;
            //        }
            //        if (con.State == ConnectionState.Open)
            //        {
            //            con.Dispose();
            //        }



            //    }
            //    catch (Exception ex)
            //    {

            //        Console.WriteLine(ex.Message);

            //    }
            //    return restaurant;
            //}

            public void SaveDetails(Restaurant r)
            {

                using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-75OND6D\EMADSQL;Initial Catalog=RestaurantDetails; User Id = sa ; Password= 123456"))
                {
                    SqlCommand cmd;
                    con.Open();
                    string s = "insert into tblCustomer values(@CustomerName,@CustomerGender,@Password)";
                    cmd = new SqlCommand(s, con);
                    cmd.Parameters.AddWithValue("@CustomerName", r.Name);
                    cmd.Parameters.AddWithValue("@CustomerGender", r.Gender);
                    cmd.Parameters.AddWithValue("@Password", r.Psw);

                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.Close();

                }



            }


        }
    }



    

