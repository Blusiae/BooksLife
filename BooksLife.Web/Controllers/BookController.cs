using AutoMapper;
using BooksLife.Core;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BooksLife.Web
{
    public class BookController : Controller
    {
        private readonly IBookManager _bookManager;
        private readonly IAuthorManager _authorManager;
        private readonly IMapper _mapper;

        public BookController(IBookManager bookManager, IAuthorManager authorManager, IMapper mapper)
        {
            _bookManager = bookManager;
            _authorManager = authorManager;
            _mapper = mapper;
        }

        public IActionResult Index(Guid id)
        {
            var bookDto = _bookManager.Get(id);
            var bookViewModel = _mapper.Map<BookViewModel>(bookDto);
            return View(bookViewModel);
        }

        public IActionResult Add()
        {
            var authorDtos = _authorManager.GetAll();
            ViewBag.Authors = _mapper.Map<List<AuthorViewModel>>(authorDtos);
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddBookViewModel bookViewModel)
        {
            if (!ModelState.IsValid)
            {
                var authorDtos = _authorManager.GetAll();
                ViewBag.Authors = _mapper.Map<List<AuthorViewModel>>(authorDtos);
                return View(bookViewModel);
            }

            var bookDto = _mapper.Map<AddBookDto>(bookViewModel);
            var result = _bookManager.Add(bookDto);
            return RedirectToAction("List", result);
        }

        public IActionResult List(int? page, string? filterString = null, Response? response = null)
        {
            ViewBag.Response = response;
            ViewBag.FilterString = filterString;

            int pageSize = 10;
            int pageNumber = page ?? 1;

            var bookDtos = _bookManager.GetPage(pageSize, pageNumber, filterString, out int totalCount);
            var bookViewModels = _mapper.Map<List<BookViewModel>>(bookDtos);
            var pagedList = new StaticPagedList<BookViewModel>(bookViewModels, pageNumber, pageSize, totalCount);

            return View(pagedList);
        }

        public IActionResult Remove(Guid id)
        {
            var response = _bookManager.Remove(id);
            return RedirectToAction("List", response);
        }
    }
}
