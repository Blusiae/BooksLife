using BooksLife.Core;
using BooksLife.Web;
using FluentAssertions;
using Xunit;

namespace BooksLife.Tests
{
    public class ViewModelMapperTests
    {
        [Fact]
        public void Map_ForAuthorViewModelObject_ShouldReturnAuthorDtoObjectWithCorrectProperties()
        {
            var mapper = new ViewModelMapper();
            var authorViewModel = new AuthorViewModel { Id = Guid.NewGuid(), Firstname = "Firstname1", Lastname = "Lastname1" };

            var authorDto = mapper.Map(authorViewModel);

            authorDto.Should().BeOfType<AuthorDto>();
            authorDto.Should().BeEquivalentTo(authorViewModel);
        }

        [Fact]
        public void Map_ForAuthorDtoObject_ShouldReturnAuthorViewModelObjectWithCorrectProperties()
        {
            var mapper = new ViewModelMapper();
            var authorDto = new AuthorDto { Id = Guid.NewGuid(), Firstname = "Firstname1", Lastname = "Lastname1" };

            var authorViewModel = mapper.Map(authorDto);

            authorViewModel.Should().BeOfType<AuthorViewModel>();
            authorViewModel.Should().BeEquivalentTo(authorDto);
        }

        [Fact]
        public void Map_ForListOfAuthorViewModelObjects_ShouldReturnListOfAuthorDtoObjectsWithCorrectProperties()
        {
            var mapper = new ViewModelMapper();
            var authorViewModels = new List<AuthorViewModel>()
            {
                new AuthorViewModel { Id = Guid.NewGuid(), Firstname = "Firstname1", Lastname = "Lastname1" },
                new AuthorViewModel { Id = Guid.NewGuid(), Firstname = "Firstname2", Lastname = "Lastname2" },
                new AuthorViewModel { Id = Guid.NewGuid(), Firstname = "Firstname3", Lastname = "Lastname2" }
            };

            var authorDtos = mapper.Map(authorViewModels);

            authorDtos.Should().BeOfType<List<AuthorDto>>();
            authorDtos.Should().BeEquivalentTo(authorViewModels);
        }

        [Fact]
        public void Map_ForListOfAuthorDtoObjects_ShouldReturnListOfAuthorViewModelObjectsWithCorrectProperties()
        {
            var mapper = new ViewModelMapper();
            var authorDtos = new List<AuthorDto>()
            {
                new AuthorDto { Id = Guid.NewGuid(), Firstname = "Firstname1", Lastname = "Lastname1" },
                new AuthorDto { Id = Guid.NewGuid(), Firstname = "Firstname2", Lastname = "Lastname2" },
                new AuthorDto { Id = Guid.NewGuid(), Firstname = "Firstname3", Lastname = "Lastname2" }
            };

            var authorViewModels = mapper.Map(authorDtos);

            authorViewModels.Should().BeOfType<List<AuthorViewModel>>();
            authorViewModels.Should().BeEquivalentTo(authorDtos);
        }
    }
}
