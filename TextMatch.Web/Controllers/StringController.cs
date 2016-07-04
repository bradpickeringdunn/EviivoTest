using TextMatch.Domain;
using TextMatch.Web.Actions;
using TextMatch.Web.Models;
using NLog;
using System.Web.Mvc;

namespace TextMatch.Web.Controllers
{
    public class StringController : Controller
    {
        private ILogger logger;
        private ITextMatch stringMatch;

        public StringController(ILogger logger, ITextMatch stringMatch)
        {
            this.stringMatch = stringMatch;
            this.logger = logger;
        }

        [HttpPost]
        // GET: String
        public ActionResult Match(TestMatchViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View("~/views/home/index.cshtml", model);
            }
            else
            {
                return new StringMatchAction<ActionResult>(logger, stringMatch)
                {
                    OnComplete = (m) => View("~/views/home/index.cshtml", m)
                }.Execute(model);
            }
        }
    }
}