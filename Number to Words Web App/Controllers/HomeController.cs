using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Number_to_Words_Web_App.Models;
using System;
using System.Diagnostics;

namespace Number_to_Words_Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string Numeric)
        {
            var model = new HomeModel();
            try
            {
                model.ResultType = "class=";
                model.NonNumerical = HandleNumericConversion(Numeric);
            }
            catch (Exception e)
            {
                model.ResultType = "class=Error";
                model.NonNumerical = e.Message;

            }
            return View(model);
        }

        string HandleNumericConversion(string val)
        {
            string result = "Enter Numeric Number Above";
            if (!string.IsNullOrWhiteSpace(val))
            {
                result = val.ConvertNumToWords();
            }
            return result;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
