using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Helpers;
using DAL.App.EF.Mappers;
using ee.itcollege.sigrid.narep.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Address = DAL.App.DTO.Address;



namespace DAL.App.EF.Repositories
{
    public class AddressRepository : BaseRepository<DAL.App.DTO.Address, Domain.Address, AppDbContext>, IAddressRepository
    {
        public AddressRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new AddressMapper())
        {
        }
        
//        public override async Task<Address> FindAsync(params object[] id)
//        {
//            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
//            
//            var address = await RepositoryDbSet.FindAsync(id);
//            if (address != null)
//            {
//                await RepositoryDbContext.Entry(address)
//                    .Reference(c => c.Country)
//                    .LoadAsync();
//                await RepositoryDbContext.Entry(address)
//                    .Reference(c => c.City)
//                    .LoadAsync();
//                
//                await RepositoryDbContext.Entry(address.Country)
//                    .Collection(b => b.Translations)
//                    .Query()
//                    .Where(t => t.Culture == culture)
//                    .LoadAsync();
//                await RepositoryDbContext.Entry(address.City)
//                    .Collection(b => b.Translations)
//                    .Query()
//                    .Where(t => t.Culture == culture)
//                    .LoadAsync();
//            }
// 
//            return AddressMapper.MapFromDomain(address);
//        }
//
//        public override Address Update(Address entity)
//        {
//            var entityInDb = RepositoryDbSet
//                .Include(m => m.Country)
//                .Include(m => m.City)
//                .ThenInclude(t => t.Translations)
//                .FirstOrDefault(x => x.Id == entity.Id);
//
//            entityInDb.Country.SetTranslation(entity.Country);
//            entityInDb.City.SetTranslation(entity.City);
//
//            return entity;
//        }
    }
}