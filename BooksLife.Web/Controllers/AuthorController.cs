using BooksLife.Core;
using Microsoft.AspNetCore.Mvc;

namespace BooksLife.Web
{
    public class AuthorController : Controller
    {
        private readonly IAuthorManager _authorManager;

        public AuthorController(IAuthorManager authorManager)
        {
            _authorManager = authorManager;
        }

        public IActionResult List(Response? response = null)
        {
            ViewBag.Response = response;
            var authorDtos = _authorManager.GetAll();
            var authorViewModels = authorDtos.ToViewModel();
            return View(authorViewModels);
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

            var authorDto = authorVM.ToDto();
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
