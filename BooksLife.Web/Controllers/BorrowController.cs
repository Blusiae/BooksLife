using BooksLife.Core;
using Microsoft.AspNetCore.Mvc;

namespace BooksLife.Web
{
    public class BorrowController : Controller
    {
        private readonly IViewModelMapper _mapper;
        private readonly IBorrowManager _borrowManager;
        private readonly IBookManager _bookManager;
        private readonly IReaderManager _readerManager;

        public BorrowController(IViewModelMapper mapper, IBorrowManager borrowManager, IBookManager bookManager, IReaderManager readerManager)
        {
            _mapper = mapper;
            _borrowManager = borrowManager;
            _bookManager = bookManager;
            _readerManager = readerManager;
        }

        public IActionResult Index(Guid id)
        {
            var borrowDto = _borrowManager.Get(id);
            var borrowViewModel = _mapper.Map(borrowDto);
            return View(borrowViewModel);
        }

        public IActionResult Add()
        {
            var bookDtos = _bookManager.GetAll().Where(x => !x.IsBorrowed).ToList(); //move it  to BookManager later
            ViewBag.Books = _mapper.Map(bookDtos);

            var readerDtos = _readerManager.GetAllForList();
            ViewBag.Readers = _mapper.Map(readerDtos);

            return View();
        }

        [HttpPost]
        public IActionResult Add(BorrowViewModel borrowViewModel) 
        {
            if (!ModelState.IsValid)
            {
                var bookDtos = _bookManager.GetAll().Where(x => !x.IsBorrowed).ToList(); //move it  to BookManager later
                ViewBag.Books = _mapper.Map(bookDtos);

                var readerDtos = _readerManager.GetAllForList();
                ViewBag.Readers = _mapper.Map(readerDtos);

                return View(borrowViewModel);
            }

            var borrowDto = _mapper.Map(borrowViewModel);
            var response = _borrowManager.Add(borrowDto);
            return RedirectToAction("List", response);
        }

        public IActionResult List(Response? response = null)
        {
            ViewBag.Response = response;
            var borrowDtos = _borrowManager.GetAll();
            var borrowViewModels = _mapper.Map(borrowDtos);
            return View(borrowViewModels);
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
