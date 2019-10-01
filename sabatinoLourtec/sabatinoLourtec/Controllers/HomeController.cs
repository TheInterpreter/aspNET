using sabatinoLourtec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sabatinoLourtec.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DBContext ctx = new DBContext("Server=tcp:sabatino.database.windows.net,1433;Initial Catalog=dbSabatino;Persist Security Info=False;User ID={whytsler};Password={Pa$$w0rd};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var List = ctx.GetList("");
            return View();
        }
    }
}