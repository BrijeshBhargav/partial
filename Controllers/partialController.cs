using Microsoft.AspNetCore.Mvc;
using MVCWebAppHTD3.Models;
using MVCWebAppHTD3.BusinessLogic_bl;
using Microsoft.CodeAnalysis.VisualBasic;
using System.Data.SqlClient;
using System.Data;
using System.Dynamic;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MVCWebAppHTD3.Controllers
{
    public class partialController : Controller
    {
        [HttpGet]
        public IActionResult insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult insert(AddressModel obj)
        {

            if (ModelState.IsValid)
            {
                bool res = partial_bl.InsertData(obj);
                if (res)
                {
                    ViewBag.Message = "Data Inserted Sucessfully...";
                    
                }
                else
                {
                    ViewBag.Message = "Fail";
                }
                return View(obj);
            }
            else
            {
                return View(obj);
            }
        }

        [HttpGet]
        public IActionResult insert2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult insert2(FamilyModel obj)
        {
            
                if (ModelState.IsValid)
                {
                    bool res = partial_bl.InsertData2(obj);
                    if (res)
                    {
                        ViewBag.Message = "Data Inserted Sucessfully...";
                    }
                    else
                    {
                        ViewBag.Message = "Fail";
                    }
                    return View(obj);
                }
                else
                {
                    return View(obj);
                }
            }
        [HttpGet]
        public IActionResult Homepage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Display()
        {
            return View(partial_bl.GetAllData());
        }
       
        public IActionResult Dis()
        {
            return View();
        }
        public IActionResult Dis2()
        {
            return View();
        }

        public IActionResult Display4()
        {
            return View();
        }
        public IActionResult Display3()
        {
            dynamic model = new ExpandoObject();
            model.Address = GetAddress();
            model.Family = GetFamily();
            return View(model);
        }
        private static List<AddressModel> GetAddress()
        {
            List<AddressModel> address = new List<AddressModel>();
            var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("select * from Address", con);
               // cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        address.Add(new AddressModel
                        {
                            Name = sdr["Name"].ToString(),
                            City = sdr["City"].ToString(),
                           
                            State = sdr["State"].ToString()

                        });
                    }
                }
                con.Close();
                return address;
            }
        }
        private static List<FamilyModel> GetFamily()
        {
            List<FamilyModel> family = new List<FamilyModel>();
            var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("select * from Family", con);
               // cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        family.Add(new FamilyModel
                        {


                            DoorNo = sdr["DoorNo"].ToString(),
                                                   
                            FatherName = sdr["FatherName"].ToString(),
                            MotherName = sdr["MotherName"].ToString(),
                        });
                    }
                    con.Close();
                    return family;
                }
            }
        }
    }
}
