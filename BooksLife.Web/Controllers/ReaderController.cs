using BooksLife.Core;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BooksLife.Web
{
    public class ReaderController : Controller
    {
        private readonly IReaderManager _readerManager;

        public ReaderController(IReaderManager readerManager)
        {
            _readerManager = readerManager;
        }

        public IActionResult Index(Guid id)
        {
            var readerDto = _readerManager.Get(id);
            var readerVm = readerDto.ToViewModel();
            return View(readerVm);
        }

        public IActionResult List(int? page, string? filterString = null, Response? response = null)
        {
            ViewBag.Response = response;
            ViewBag.FilterString = filterString;

            int pageSize = 10;
            int pageNumber = page ?? 1;

            var readerDtos = _readerManager.GetAll(pageSize, pageNumber, filterString, out int totalCount);
            var readerViewModels = readerDtos.ToViewModel();

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

            var readerDto = readerViewModel.ToDto(); 
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
