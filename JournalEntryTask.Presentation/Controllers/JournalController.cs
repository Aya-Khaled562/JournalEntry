using JournalEntryTask.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JournalEntryTask.Presentation.Controllers
{
    public class JournalController : Controller
    {

        public JournalController()
        {}

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult JournalForm(Guid id)
        {
            return View();
        }

        public IActionResult JournalDetailsForm(Guid id)
        {
            return View();
        }
    }
}
