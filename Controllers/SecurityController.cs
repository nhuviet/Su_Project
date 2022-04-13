using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Su_Project.Models;
using Microsoft.Data.SqlClient;

namespace Su_Project.Controllers
{
    public class SecurityController : Controller
    {
        //GET: Account
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        [HttpGet]
        public IActionResult Logon()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        void connectionString() 
        {
            con.ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=RiviuNhaTrang;MultipleActiveResultSets=true";
        }
        [HttpPost]
        public IActionResult Verify(User useracc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM dbo.UserAccount WHERE UserName = '" + useracc.AccountName + "' AND Pass = '"+useracc.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Logon");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }
    }
}
