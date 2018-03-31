namespace simple_todo.Controllers {
    using Microsoft.AspNetCore.Mvc;
    using simple_todo.Services;

    public class HomeController : Controller {
        private readonly TodoService service = new TodoService();
        public IActionResult Index() => View(TodoService.Data);

        public IActionResult Edit() => View();

        public IActionResult Search() => View();

        public IActionResult LookUp(string q) =>
              View("Search",  service.Find(q));

        public IActionResult Add() => View();

        public IActionResult SaveNew(string text) =>
            service
            .AddNewTodo(text)
            .Match<IActionResult>(
                x => View("SavedSuccessfully", x),
                () => View("Add", "Invalid value")
            );
    }
}