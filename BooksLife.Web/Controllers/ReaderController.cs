using BooksLife.Core;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult List(Response? response = null)
        {
            ViewBag.Response = response;
            var readerDtos = _readerManager.GetAll();
            var readerVMs = readerDtos.ToViewModel();
            return View(readerVMs);
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
