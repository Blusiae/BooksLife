using AutoMapper;
using BooksLife.Core;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BooksLife.Web
{
    public class ReaderController : Controller
    {
        private readonly IReaderManager _readerManager;
        private readonly IMapper _mapper;

        public ReaderController(IReaderManager readerManager, IMapper mapper)
        {
            _readerManager = readerManager;
            _mapper = mapper;
        }

        public IActionResult Index(Guid id)
        {
            var readerDto = _readerManager.Get(id);
            var readerVm = _mapper.Map<ReaderViewModel>(readerDto);
            return View(readerVm);
        }

        public IActionResult List(int? page, string? filterString = null, Response? response = null)
        {
            ViewBag.Response = response;
            ViewBag.FilterString = filterString;

            int pageSize = 10;
            int pageNumber = page ?? 1;

            var readerDtos = _readerManager.GetPage(pageSize, pageNumber, filterString, out int totalCount);
            var readerViewModels = _mapper.Map<List<ReaderViewModel>>(readerDtos);

            var pagedList = new StaticPagedList<ReaderViewModel>(readerViewModels, pageNumber, pageSize, totalCount);

            return View(pagedList);
        }

        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddReaderViewModel readerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(readerViewModel);
            }

            var readerDto = _mapper.Map<AddReaderDto>(readerViewModel);
            var response = _readerManager.Add(readerDto);
            return RedirectToAction("List", response);
        }

        public IActionResult Remove(Guid id) 
        {
            var response = _readerManager.Remove(id);
            return RedirectToAction("List", response);
        }
    }
}
