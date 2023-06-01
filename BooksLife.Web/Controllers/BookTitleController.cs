using BooksLife.Core;
using Microsoft.AspNetCore.Mvc;

namespace BooksLife.Web
{
    public class BookTitleController : Controller
    {
        private readonly IBookTitleManager _bookTitleManager;
        private readonly IViewModelMapper _viewModelMapper;
        private readonly IAuthorManager _authorManager;

        public BookTitleController(IBookTitleManager bookTitleManager, IViewModelMapper viewModelMapper,
            IAuthorManager authorManager)
        {
            _bookTitleManager = bookTitleManager;
            _viewModelMapper = viewModelMapper;
            _authorManager = authorManager;
        }

        public IActionResult List(Response? response = null)
        {
            ViewBag.Response = response;
            var bookTitleDtos = _bookTitleManager.GetAll();
            var bookTitleViewModels = _viewModelMapper.Map(bookTitleDtos);
            return View(bookTitleViewModels);
        }

        [HttpPost]
        public IActionResult Add(BookTitleViewModel bookTitleViewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(bookTitleViewmodel);
            }

            var bookTitleDto = _viewModelMapper.Map(bookTitleViewmodel);
            var response = _bookTitleManager.Add(bookTitleDto);
            return RedirectToAction("List", response);
        }

        public IActionResult Add()
        {
            var authorDtos = _authorManager.GetAll();
            ViewBag.Authors = _viewModelMapper.Map(authorDtos);
            return View();
        }

        public IActionResult Remove(Guid id)
        {
            var response = _bookTitleManager.Remove(id);
            return RedirectToAction("List", response);
        }
    }
}
