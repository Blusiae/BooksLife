using BooksLife.Core;
using Microsoft.AspNetCore.Mvc;

namespace BooksLife.Web
{
    public class BookTitleController : Controller
    {
        private readonly IBookTitleManager _bookTitleManager;
        private readonly IAuthorManager _authorManager;

        public BookTitleController(IBookTitleManager bookTitleManager, IAuthorManager authorManager)
        {
            _bookTitleManager = bookTitleManager;
            _authorManager = authorManager;
        }

        public IActionResult List(Response? response = null)
        {
            ViewBag.Response = response;
            var bookTitleDtos = _bookTitleManager.GetAll();
            var bookTitleViewModels = bookTitleDtos.ToViewModel();
            return View(bookTitleViewModels);
        }

        [HttpPost]
        public IActionResult Add(AddBookTitleViewModel bookTitleViewmodel)
        {
            if (!ModelState.IsValid)
            {
                var authorDtos = _authorManager.GetAll();
                ViewBag.Authors = authorDtos.ToViewModel();
                return View(bookTitleViewmodel);
            }

            var bookTitleDto = bookTitleViewmodel.ToDto();
            var response = _bookTitleManager.Add(bookTitleDto);
            return RedirectToAction("List", response);
        }

        public IActionResult Add()
        {
            var authorDtos = _authorManager.GetAll();
            ViewBag.Authors = authorDtos.ToViewModel();
            return View();
        }

        public IActionResult Remove(Guid id)
        {
            var response = _bookTitleManager.Remove(id);
            return RedirectToAction("List", response);
        }
    }
}
