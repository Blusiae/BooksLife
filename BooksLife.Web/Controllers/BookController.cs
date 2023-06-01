using BooksLife.Core;
using Microsoft.AspNetCore.Mvc;

namespace BooksLife.Web
{
    public class BookController : Controller
    {
        private readonly IBookManager _bookManager;
        private readonly IBookTitleManager _bookTitleManager;
        private readonly IViewModelMapper _viewModelMapper;

        public BookController(IBookManager bookManager, IViewModelMapper viewModelMapper, 
            IBookTitleManager bookTitleManager)
        {
            _bookManager = bookManager;
            _viewModelMapper = viewModelMapper;
            _bookTitleManager = bookTitleManager;
        }

        public IActionResult Index(Guid id)
        {
            var bookDto = _bookManager.Get(id);
            var bookViewModel = _viewModelMapper.Map(bookDto);
            return View(bookViewModel);
        }

        public IActionResult Add()
        {
            var bookTitleDtos = _bookTitleManager.GetAll();
            ViewBag.BookTitles = _viewModelMapper.Map(bookTitleDtos);
            return View();
        }

        public IActionResult Add(BookViewModel bookViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(bookViewModel);
            }

            var bookDto = _viewModelMapper.Map(bookViewModel);
            var result = _bookManager.Add(bookDto);
            return RedirectToAction("List", result);
        }

        public IActionResult List(Response? response = null)
        {
            ViewBag.Response = response;
            var bookDtos = _bookManager.GetAll();
            var bookViewModels = _viewModelMapper.Map(bookDtos);
            return View(bookViewModels);
        }

        public IActionResult Remove(Guid id)
        {
            var response = _bookManager.Remove(id);
            return RedirectToAction("List", response);
        }
    }
}
