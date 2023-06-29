using BooksLife.Core;
using Microsoft.AspNetCore.Mvc;

namespace BooksLife.Web
{
    public class BookController : Controller
    {
        private readonly IBookManager _bookManager;
        private readonly IAuthorManager _authorManager;

        public BookController(IBookManager bookManager, IAuthorManager authorManager)
        {
            _bookManager = bookManager;
            _authorManager = authorManager;
        }

        public IActionResult Index(Guid id)
        {
            var bookDto = _bookManager.Get(id);
            var bookViewModel = bookDto.ToViewModel();
            return View(bookViewModel);
        }

        public IActionResult Add()
        {
            var authorDtos = _authorManager.GetAll();
            ViewBag.Authors = authorDtos.ToViewModel();
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddBookViewModel bookViewModel)
        {
            if (!ModelState.IsValid)
            {
                var authorDtos = _authorManager.GetAll();
                ViewBag.Authors = authorDtos.ToViewModel();
                return View(bookViewModel);
            }

            var bookDto = bookViewModel.ToDto();
            var result = _bookManager.Add(bookDto);
            return RedirectToAction("List", result);
        }

        public IActionResult List(Response? response = null)
        {
            ViewBag.Response = response;
            var bookDtos = _bookManager.GetAll();
            var bookViewModels = bookDtos.ToViewModel();
            return View(bookViewModels);
        }

        public IActionResult Remove(Guid id)
        {
            var response = _bookManager.Remove(id);
            return RedirectToAction("List", response);
        }
    }
}
