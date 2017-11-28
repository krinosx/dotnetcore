using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using DOTNETMVC.Models;
using System.Collections.Generic;

namespace DOTNETMVC.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/

       public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public IActionResult Welcome()
        {

            CotacaoDAO dao = HttpContext.RequestServices.GetService(typeof(CotacaoDAO)) as CotacaoDAO;

             List<CotacaoModel> cotacoes = dao.getCotacao();

            return View( cotacoes );
        }
    }
}