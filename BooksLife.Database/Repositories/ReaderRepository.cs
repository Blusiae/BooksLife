using BooksLife.Core;
using Microsoft.EntityFrameworkCore;

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
    }
}
