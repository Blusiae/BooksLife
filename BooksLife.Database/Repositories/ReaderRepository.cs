using BooksLife.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BooksLife.Database
{
    public class ReaderRepository : BaseRepository<ReaderEntity>, IReaderRepository
    {
        protected override DbSet<ReaderEntity> DbSet => _context.Readers;
        public ReaderRepository(ApplicationDbContext context) : base(context) { }

        public new bool Add(ReaderEntity entity)
        {
            var address = _context.Addresses.FirstOrDefault(x => 
                x.Country == entity.Address.Country
                && x.City == entity.Address.City
                && x.Street == entity.Address.Street
                && x.PostalCode == entity.Address.PostalCode
                && x.HouseNumber == entity.Address.HouseNumber
                && x.FlatNumber == entity.Address.FlatNumber);

            if(address != null)
            {
                entity.Address = address;
            }

            return base.Add(entity);
        }

        public IEnumerable<ReaderEntity> GetAll(out int totalCount, int take, int skip = 0, string? filterString = null)
        {
            var filteringMethod = new Func<ReaderEntity, bool>(x => filterString.IsNullOrEmpty()
                || string.Join(' ', x.Firstname, x.Lastname).ToLower().Contains(filterString.ToLower()));

            totalCount = Count(filteringMethod);

            return GetAll(filteringMethod, take, skip);
        }
    }
}
