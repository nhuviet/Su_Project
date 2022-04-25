using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Su_Project.Models;


namespace Su_Project.Controllers
{
    public class SecurityController : Controller
    {
        string connectString = "Server=(localdb)\\MSSQLLocalDB;Database=RiviuNhaTrang;MultipleActiveResultSets=true";

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

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=RiviuNhaTrang;MultipleActiveResultSets=true";
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM dbo.UserAccount WHERE UserName = '" + useracc.AccountName + "' AND Pass = '" + useracc.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return RedirectToAction("LogIndex", "Home");
            }
            else
            {
                con.Close();
                return View("Login");
            }
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            SqlConnection connect = new SqlConnection();
            connect.ConnectionString = connectString;
            connect.Open();
            SqlCommand cmd = new SqlCommand();

            //string checkQuery = "EXECUTE dbo.CheckExistAccount '" + user.AccountName + "'";
            cmd.Connection = connect;
            cmd.CommandText = "dbo.CheckExistAccount" + user.AccountName;
            int r = cmd.ExecuteNonQuery();
            if (r == 0)
            {
                connect.Close();
                return View("Logon");
            }

            else
            {
                string query = "INSERT INTO dbo.UserAccount VALUES('" + user.AccountName + "','"
                                                                     + user.Password + "','"
                                                                     + user.FullName + "','"
                                                                     + user.Email + "','"
                                                                     + user.Phone + "','"
                                                                     + user.FaceBook + "','"
                                                                     + user.Website + "')";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                connect.Close();
                return View("Login");
            }







        }
    }
}
