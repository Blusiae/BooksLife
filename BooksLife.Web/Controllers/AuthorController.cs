using BooksLife.Core;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BooksLife.Web
{
    public class AuthorController : Controller
    {
        private readonly IAuthorManager _authorManager;
        private readonly IViewModelMapper _viewModelMapper;

        public AuthorController(IAuthorManager authorManager, IViewModelMapper viewModelMapper)
        {
            _authorManager = authorManager;
            _viewModelMapper = viewModelMapper;
        }

        public IActionResult List(Response? response = null)
        {
            if (response != null)
            {
                ViewData["responseMessage"] = response;
            }
            var authorDtos = _authorManager.GetAll();
            var authorViewModels = _viewModelMapper.Map(authorDtos);
            return View(authorViewModels);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AuthorViewModel authorVM)
        {
            if (!ModelState.IsValid)
            {
                return View(authorVM);
            }

            var authorDto = _viewModelMapper.Map(authorVM);
            var response = _authorManager.Add(authorDto);
            return RedirectToAction("List", response);
        }

        public IActionResult Remove(int id)
        {
            var response = _authorManager.Remove(id);
            return RedirectToAction("List", response);
        }
    }
}
