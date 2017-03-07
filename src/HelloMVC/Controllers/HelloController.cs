using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloMVC.Controllers
{
    public class HelloController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method='post'>" +
                "<input type='text' name='name' />" +
                "<select name='lang'>" +
                    "<option value='french'>French</option>" +
                    "<option value='spanish'>Spanish</option>" +
                    "<option value='russian'>Russian</option>" +
                    "<option value='chinese'>Chinese</option>" +
                    "<option value='german'>German</option>" +
                "</select>" +
                "<input type='submit' value='Greet me!' />" +
                "</form>";

            return Content(html, "text/html");
        }

        // /Hello
        [Route("/Hello")]
        [HttpPost]
        public IActionResult Display(string name = "World", string lang = "chinese")
        {
            Dictionary<string, string> langDict = new Dictionary<string, string>
            {
                { "english", "Howdy!" },
                { "chinese", "Ni Hao" },
                { "french", "Bonjour" },
                { "german", "Hallo" },
                { "spanish", "Hola" }
            };

            string message = string.Format("<h1>{0} {1}!</h1>", langDict[lang], name);
            return Content(message, "text/html");
        }

        // Handle requests to /Hello/Chris (URL segement)
        [Route("/Hello/{name}")]
        public IActionResult Index2(string name)
        {
            return Content(string.Format("<h1>Hello {0}</h1>", name), "text/html");
        }

        public IActionResult Goodbye()
        {
            return Content("Goodbye");
        }
    }
}
