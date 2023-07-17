using BooksLife.Core;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BooksLife.Web
{
    public class BorrowController : Controller
    {
        private readonly IBorrowManager _borrowManager;
        private readonly IBookManager _bookManager;
        private readonly IReaderManager _readerManager;

        public BorrowController(IBorrowManager borrowManager, IBookManager bookManager, IReaderManager readerManager)
        {
            _borrowManager = borrowManager;
            _bookManager = bookManager;
            _readerManager = readerManager;
        }

        public IActionResult Index(Guid id)
        {
            var borrowDto = _borrowManager.Get(id);
            var borrowViewModel = borrowDto.ToViewModel();
            return View(borrowViewModel);
        }

        public IActionResult Add()
        {
            var bookDtos = _bookManager.GetAll(true);
            ViewBag.Books = bookDtos.ToViewModel();

            var readerDtos = _readerManager.GetAll();
            ViewBag.Readers = readerDtos.ToViewModel();

            return View();
        }

        [HttpPost]
        public IActionResult Add(AddBorrowViewModel borrowViewModel) 
        {
            if (!ModelState.IsValid)
            {
                var bookDtos = _bookManager.GetAll(true);
                ViewBag.Books = bookDtos.ToViewModel();

                var readerDtos = _readerManager.GetAll();
                ViewBag.Readers = readerDtos.ToViewModel();

                return View(borrowViewModel);
            }

            var borrowDto = borrowViewModel.ToDto();
            var response = _borrowManager.Add(borrowDto);
            return RedirectToAction("List", response);
        }

        public IActionResult List(int? page, Response? response = null)
        {
            ViewBag.Response = response;

            int pageSize = 10;

            int pageNumber = page ?? 1;

            var borrowDtos = _borrowManager.GetAll(pageSize, pageNumber, out int totalCount);
            var borrowViewModels = borrowDtos.ToViewModel();

            var pagedList = new StaticPagedList<BorrowViewModel>(borrowViewModels, pageNumber, pageSize, totalCount);

            return View(pagedList);
        }

        public IActionResult SetAsReturned(Guid id)
        {
            var borrowDto = _borrowManager.Get(id);
            var returnDto = new ReturnDto()
            {
                BorrowId = borrowDto.Id,
                BookId = borrowDto.Book.Id
            };

            var response = _borrowManager.SetAsReturned(returnDto);
            return RedirectToAction("List", response);
        }

        public IActionResult Remove (Guid id)
        {
            var response = _borrowManager.Remove(id);
            return RedirectToAction("List", response);
        }
    }
}
