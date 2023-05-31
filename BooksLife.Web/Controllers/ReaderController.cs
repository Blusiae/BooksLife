using BooksLife.Core;
using Microsoft.AspNetCore.Mvc;

namespace BooksLife.Web
{
    public class ReaderController : Controller
    {
        private IReaderManager _readerManager;
        private IViewModelMapper _viewModelMapper;

        public ReaderController(IReaderManager readerManager, IViewModelMapper viewModelMapper)
        {
            _readerManager = readerManager;
            _viewModelMapper = viewModelMapper;
        }

        public IActionResult Index(Guid id)
        {
            var readerDto = _readerManager.Get(id);
            var readerVm = _viewModelMapper.Map(readerDto);
            return View(readerVm);
        }

        public IActionResult List(Response? response = null)
        {
            ViewBag.Response = response;
            var readerDtos = _readerManager.GetAllForList();
            var readerVMs = _viewModelMapper.Map(readerDtos);
            return View(readerVMs);
        }

        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ReaderViewModel readerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(readerViewModel);
            }

            var readerDto = _viewModelMapper.Map(readerViewModel); 
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
