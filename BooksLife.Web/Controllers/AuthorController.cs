using AutoMapper;
using BooksLife.Core;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BooksLife.Web
{
    public class AuthorController : Controller
    {
        private readonly IAuthorManager _authorManager;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorManager authorManager, IMapper mapper)
        {
            _authorManager = authorManager;
            _mapper = mapper;
        }

        public IActionResult List(int? page, string? filterString = null, Response? response = null)
        {
            ViewBag.Response = response;
            ViewBag.FilterString = filterString;

            int pageSize = 10;
            int pageNumber = page ?? 1;

            var authorDtos = _authorManager.GetPage(pageSize, pageNumber, filterString, out int totalCount);
            var authorViewModels = _mapper.Map<List<AuthorViewModel>>(authorDtos);

            var pagedList = new StaticPagedList<AuthorViewModel>(authorViewModels, pageNumber, pageSize, totalCount);

            return View(pagedList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddAuthorViewModel authorVM)
        {
            if (!ModelState.IsValid)
            {
                return View(authorVM);
            }

            var authorDto = _mapper.Map<AddAuthorDto>(authorVM);
            var response = _authorManager.Add(authorDto);
            return RedirectToAction("List", response);
        }

        public IActionResult Remove(Guid id)
        {
            var response = _authorManager.Remove(id);
            return RedirectToAction("List", response);
        }
    }
}
