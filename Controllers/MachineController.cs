using Microsoft.AspNetCore.Mvc;
using MVCWebAppHTD3.Models;
using MVCWebAppHTD3.BusinessLogic_bl;
using System.Data;
using System.Data.SqlClient;

namespace MVCWebAppHTD3.Controllers
{
    public class MachineController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Machine obj, List<IFormFile> PostedFiles)
        {
            foreach (IFormFile PostedFile in PostedFiles)
            {
                string fileName = Path.GetFileName(PostedFile.FileName);
                string type = PostedFile.ContentType;
                byte[] bytes = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    PostedFile.CopyTo(ms);
                    bytes = ms.ToArray();
                }
                var dbconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
                string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
                using (SqlConnection con = new SqlConnection(dbconnectionstr))
                {
                    SqlCommand cmd = new SqlCommand("sp_Mcahine", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@Ph_no", obj.Ph_no);
                    cmd.Parameters.AddWithValue("@Idproof", obj.Idproof);
                    cmd.Parameters.AddWithValue("@IdRoof_No", obj.IdRoof_No);
                    cmd.Parameters.AddWithValue("@Member_id", obj.Member_id);
                    cmd.Parameters.AddWithValue("@Joining_Date", Convert.ToDateTime(obj.Joining_Date));
                    cmd.Parameters.AddWithValue("@Names", fileName);
                    cmd.Parameters.AddWithValue("@ContentType", type);
                    cmd.Parameters.AddWithValue("@Data", bytes);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return View();

        }
        [HttpGet]
        public IActionResult Display()
        {
            return View(Logic_bl.GetAllData2());
        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            return View(Logic_bl.GetuserByID((int)Id));
        }
        [HttpPost]
        public IActionResult Edit(Machine2 obj)
        {
            if (ModelState.IsValid)
            {
                bool res = (Logic_bl.UpdateData(obj));
                if (res == true)
                {
                    return RedirectToAction("Display", "Machine");
                }
                else
                {
                    return View(obj);
                }
            }
            return View();
        }
        public IActionResult Delete(int? Id)
        {
            bool res = Logic_bl.DeleteData((int)Id);
            if (res == true)
            {
                return RedirectToAction("Display");
            }
            else
            {
                return View();
            }
            return View();
        }
        [HttpGet]
        public IActionResult Register2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register2(Machine3 obj)
        {
            if (ModelState.IsValid)
            {
                bool res = Logic_bl.InsertData2(obj);
                if (res == true)
                {
                    return View("Register2");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Display2()
        {
            return View(Logic_bl.GetAllData3());
        }
        [HttpGet]
        public IActionResult Edit2(int? Id)
        {
            return View(Logic_bl.GetuserByID2((int)Id));
        }
        [HttpPost]
        public IActionResult Edit2(Machine3 obj)
        {
            if (ModelState.IsValid)
            {
                bool res = (Logic_bl.UpdateData2(obj));
                if (res == true)
                {
                    return RedirectToAction("Display2", "Machine");
                }
                else
                {
                    return View(obj);
                }
            }
            return View();
        }
        public IActionResult Delete2(int? Id)
        {
            bool res = Logic_bl.DeleteData2((int)Id);
            if (res == true)
            {
                return RedirectToAction("Display2");
            }
            else
            {
                return View();
            }
            return View();
        }
    }
}
