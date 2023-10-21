using AutoMapper;
using BooksLife.Core;

namespace BooksLife.Web
{
    public class ApplicationMappingProfile: Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<ReaderEntity, ReaderDto>()
                .ForMember(m => m.Country, c => c.MapFrom(s => s.Address.Country))
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.HouseNumber, c => c.MapFrom(s => s.Address.HouseNumber))
                .ForMember(m => m.FlatNumber, c => c.MapFrom(s => s.Address.FlatNumber));

            CreateMap<BorrowEntity, BorrowDto>();

            CreateMap<BookEntity, BookDto>()
                .ForMember(m => m.Title, c => c.MapFrom(s => s.BookTitle.Title))
                .ForMember(m => m.PublicationYear, c => c.MapFrom(s => s.BookTitle.PublicationYear))
                .ForMember(m => m.AuthorName, c => c.MapFrom(s => $"{s.BookTitle.Author.Firstname} {s.BookTitle.Author.Lastname}"));
        }
    }
}
