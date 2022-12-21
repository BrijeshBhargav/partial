using System.Data.SqlClient;
using System.Data;
using MVCWebAppHTD3.Models;

namespace MVCWebAppHTD3.BusinessLogic_bl
{
    public class partial_bl
    {
        public static bool InsertData(AddressModel obj)
        {
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_insertAdd", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@City", obj.City);
                    cmd.Parameters.AddWithValue("@State", obj.State);
                    
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        return res = true;
                    }
                    else
                    {
                        return res = false;
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    con.Close();
                }
                return res = true;
            }
        }
        public static bool InsertData2(FamilyModel obj)
        {
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_insertFam", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoorNo", obj.DoorNo);
                    cmd.Parameters.AddWithValue("@FatherName", obj.FatherName);
                    cmd.Parameters.AddWithValue("@MotherName", obj.MotherName);
                   

                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        return res = true;
                    }
                    else
                    {
                        return res = false;
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    con.Close();
                }
                return res = true;
            }
        }
        public static List<FamilyAddModel> GetAllData()
        {
            List<FamilyAddModel> obj = new List<FamilyAddModel>();
            var dbconfig = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_display",con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(
                        new FamilyAddModel
                        {
                            Name = dr["Name"].ToString(),
                            City = dr["City"].ToString(),
                            State = dr["State"].ToString(),
                            FatherName= dr["FatherName"].ToString(),
                            MotherName= dr["MotherName"].ToString(),
                        }
                        );
                }

                return obj;

            }
        }
        public static List<AddressModel> GetAllData2()
        {
            List<AddressModel> obj = new List<AddressModel>();
            var dbconfig = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Address", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(
                        new AddressModel
                        {
                            Name = dr["Name"].ToString(),
                            City = dr["City"].ToString(),
                            State = dr["State"].ToString(),
                        }
                        );
                }

                return obj;

            }
        }
    }
}
