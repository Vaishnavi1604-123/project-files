using ado.net_basics_mvc_.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ado.net_basics_mvc_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        System.Data.SqlClient.SqlConnection _con;

        public HomeController(ILogger<HomeController> logger)
        {
            _con = new System.Data.SqlClient.SqlConnection("Data Source=VGATTU-L-5481;Initial Catalog=Exercise;User ID=SA;Password=Welcome2evoke@1234");
            _con.Open();
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //by default GETMETHOD
        public IActionResult StuView()
        {
            return View();
        }
        [HttpPost]
        public IActionResult StuView(student stu) 
        {
            SqlDataAdapter SDA = new SqlDataAdapter();
            SDA.SelectCommand = new SqlCommand("select * from student", _con);


            SDA.InsertCommand = new SqlCommand("insert into student values(@id,@name)", _con);
            SDA.InsertCommand.Parameters.AddWithValue("@id", stu.id);
            SDA.InsertCommand.Parameters.AddWithValue("@name", stu.name);
            
            int result = SDA.InsertCommand.ExecuteNonQuery();



             


            return View("StuView",stu);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}