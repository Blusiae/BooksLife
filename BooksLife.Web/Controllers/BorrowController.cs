using AutoMapper;
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
        private readonly IMapper _mapper;

        public BorrowController(IBorrowManager borrowManager, IBookManager bookManager, IReaderManager readerManager, IMapper mapper)
        {
            _borrowManager = borrowManager;
            _bookManager = bookManager;
            _readerManager = readerManager;
            _mapper = mapper;
        }

        public IActionResult Index(Guid id)
        {
            var borrowDto = _borrowManager.Get(id);
            var borrowViewModel = _mapper.Map<BorrowViewModel>(borrowDto);
            return View(borrowViewModel);
        }

        public IActionResult Add()
        {
            var bookDtos = _bookManager.GetAllUnborrowed();
            ViewBag.Books = _mapper.Map<List<BookViewModel>>(bookDtos);

            var readerDtos = _readerManager.GetAll();
            ViewBag.Readers = _mapper.Map<List<ReaderViewModel>>(readerDtos);

            return View();
        }

        [HttpPost]
        public IActionResult Add(AddBorrowViewModel borrowViewModel) 
        {
            if (!ModelState.IsValid)
            {
                var bookDtos = _bookManager.GetAllUnborrowed();
                ViewBag.Books = _mapper.Map<List<BookViewModel>>(bookDtos);

                var readerDtos = _readerManager.GetAll();
                ViewBag.Readers = _mapper.Map<List<ReaderViewModel>>(readerDtos);

                return View(borrowViewModel);
            }

            var borrowDto = _mapper.Map<AddBorrowDto>(borrowViewModel);
            var response = _borrowManager.Add(borrowDto);
            return RedirectToAction("List", response);
        }

        public IActionResult List(int? page, Response? response = null)
        {
            ViewBag.Response = response;

            int pageSize = 10;

            int pageNumber = page ?? 1;

            var borrowDtos = _borrowManager.GetPage(pageSize, pageNumber, out int totalCount);
            var borrowViewModels = _mapper.Map<List<BorrowViewModel>>(borrowDtos);

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
