using System.Data.SqlClient;
using System.Data;
using MVCWebAppHTD3.Models;
using static System.Reflection.Metadata.BlobBuilder;
using System.Net.Mime;

namespace MVCWebAppHTD3.BusinessLogic_bl
{
    public class Logic_bl
    {
        public static bool InsertData(Machine obj)
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
                    cmd.Parameters.AddWithValue("@Ph_no", obj.Ph_no);
                    cmd.Parameters.AddWithValue("@Idproof", obj.Idproof);
                    cmd.Parameters.AddWithValue("@IdRoof_No", obj.IdRoof_No);
                    cmd.Parameters.AddWithValue("@Member_id", obj.Member_id);
                    cmd.Parameters.AddWithValue("@Joining_Date", obj.Joining_Date);
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
        public static List<Machine> GetAllData2()
        {
            List<Machine> obj = new List<Machine>();
            var dbconfig = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from machine", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(
                        new Machine
                        {
                            Id = Convert.ToInt32(dr["Id"].ToString()),
                            Name = dr["Name"].ToString(),
                            Ph_no = dr["Ph_no"].ToString(),
                            Idproof = dr["Idproof"].ToString(),
                            IdRoof_No = dr["IdRoof_No"].ToString(),
                            Member_id = dr["Member_id"].ToString(),
                            Joining_Date = Convert.ToDateTime(dr["Joining_Date"].ToString()),
                         
                        }
                        );
                }

                return obj;

            }
        }
        public static Machine2 GetuserByID(int Id)
        {
            Machine2 obj = null;
            var dbconfig = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("sp_getmachinedatabyId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    obj = new Machine2();
                    

                    obj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    obj.Ph_no = ds.Tables[0].Rows[i]["Ph_no"].ToString();
                    obj.Idproof = ds.Tables[0].Rows[i]["Idproof"].ToString();
                    obj.IdRoof_No = ds.Tables[0].Rows[i]["IdRoof_No"].ToString();
                    obj.Member_id = ds.Tables[0].Rows[i]["Member_id"].ToString();
                    obj.Joining_Date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Joining_Date"].ToString());



                }
                return obj;
            }
        }

        public static bool UpdateData(Machine2 obj)
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
                    SqlCommand cmd = new SqlCommand("sp_updatemachine", con);
                    cmd.CommandType = CommandType.StoredProcedure;
             
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@Ph_no", obj.Ph_no);
                    cmd.Parameters.AddWithValue("@Idproof", obj.Idproof);
                    cmd.Parameters.AddWithValue("@IdRoof_No", obj.IdRoof_No);
                    cmd.Parameters.AddWithValue("@Member_id", obj.Member_id);
                    cmd.Parameters.AddWithValue("@Joining_Date", Convert.ToDateTime(obj.Joining_Date));
                    cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(obj.Id));
                   
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
        public static bool DeleteData(int Id)
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
                    SqlCommand cmd = new SqlCommand("sp_deletemachine", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);

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
        public static bool InsertData2(Machine3 obj)
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
                    SqlCommand cmd = new SqlCommand("sp_empData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@Designation", obj.Designation);
                    cmd.Parameters.AddWithValue("@salary", obj.salary);
                    cmd.Parameters.AddWithValue("@Email", obj.Email);
                    cmd.Parameters.AddWithValue("@Mobile", obj.Mobile);
                    cmd.Parameters.AddWithValue("@Qualification", obj.Qualification);
                    cmd.Parameters.AddWithValue("@Manager", obj.Manager);
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
        public static List<Machine3> GetAllData3()
        {
            List<Machine3> obj = new List<Machine3>();
            var dbconfig = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from register", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(
                        new Machine3
                        {
                            Id = Convert.ToInt32(dr["Id"].ToString()),
                            Name = dr["Name"].ToString(),
                            Designation = dr["Designation"].ToString(),
                            salary = Convert.ToInt32(dr["salary"].ToString()),
                            Email = dr["Email"].ToString(),
                            Mobile = dr["Mobile"].ToString(),
                            Qualification = dr["Qualification"].ToString(),
                            Manager = dr["Manager"].ToString(),

                        }
                        );
                }

                return obj;

            }
        }
        public static Machine3 GetuserByID2(int Id)
        {
            Machine3 obj = null;
            var dbconfig = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("sp_empbyid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    obj = new Machine3();


                    obj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    obj.Designation = ds.Tables[0].Rows[i]["Designation"].ToString();
                    obj.salary = Convert.ToInt32(ds.Tables[0].Rows[i]["salary"].ToString());
                    obj.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                    obj.Mobile = ds.Tables[0].Rows[i]["Mobile"].ToString();
                    obj.Qualification = ds.Tables[0].Rows[i]["Qualification"].ToString();
                    obj.Manager = ds.Tables[0].Rows[i]["Manager"].ToString();



                }
                return obj;
            }
        }

        public static bool UpdateData2(Machine3 obj)
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
                    SqlCommand cmd = new SqlCommand("sp_updateres", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@Designation", obj.Designation);
                    cmd.Parameters.AddWithValue("@salary", Convert.ToInt32(obj.salary));
                    cmd.Parameters.AddWithValue("@Email", obj.Email);
                    cmd.Parameters.AddWithValue("@Mobile", obj.Mobile);
                    cmd.Parameters.AddWithValue("@Qualification", obj.Qualification);
                    cmd.Parameters.AddWithValue("@Manager", obj.Manager);
                    cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(obj.Id));

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
        public static bool DeleteData2(int Id)
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
                    SqlCommand cmd = new SqlCommand("sp_deleteres", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);

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
    }
}
