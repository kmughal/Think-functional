namespace FunctionalApp.Controllers
{
    using FunctionalApp.Service;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly StudentRecordService service = new StudentRecordService();
        public IActionResult Index() => View();

        public IActionResult Search() => View();

        public IActionResult LookUp(string q) =>
            View("Search", service.FindByFirstName(q));

        public IActionResult Add() => View();

        public IActionResult SaveNew(string firstname, string lastname, int age, string gender) =>
            service
            .AddNewStudent(firstname, lastname, age, gender)
            .Match<IActionResult>(
                x => View("SavedSuccessfully", x),
                () => View("Add", "Invalid value")
            );
    }
}