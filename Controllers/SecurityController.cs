using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Su_Project.Models;
using Microsoft.Data.SqlClient;
using Su_Project.DataContext;
using System.Web;
namespace Su_Project.Controllers
{
    public class SecurityController : Controller
    {
        //private readonly RiviuNhaTrangDBContext _context;
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        //GET: Account

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
                return RedirectToAction("Index","Home");
            }
            else
            {
                con.Close();
                return View("Login");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "INSERT INTO dbo.UserAccount VALUES('" + user.AccountName + "','"
                                                                     + user.Password + "','"
                                                                     + user.FullName + "','"
                                                                     + user.Email + "','"
                                                                     + user.Phone + "','"
                                                                     + user.FaceBook + "','"
                                                                     + user.Website + "')";
           
            con.Close();
            return View("Login");

            //Past 2
            //if (ModelState.IsValid)
            //{
            //    _context.Add(user);
            //    await _context.SaveChangesAsync();
            //    //return RedirectToAction(nameof(Index));
            //    return View("Login");
            //}
            //return View();


            //var sqlconnectstring = @"Data Source=localhost,1433;
            //                 Initial Catalog=xtlab;
            //                 User ID=SA;Password=Password123";
            //var connection = new SqlConnection(sqlconnectstring);
            //connection.Open();

            //// Tạo đối tượng DbCommand
            //using var command = new SqlCommand();
            //command.Connection = connection;
            //// select, insert, update, delete
            //command.CommandText = "Mệnh đề truy vấn SQL";

            //// Thực hiện các câu truy vấn, đọc kết quả
            //// ...
            //// ...

            //connection.Close();
        }


    }
}
