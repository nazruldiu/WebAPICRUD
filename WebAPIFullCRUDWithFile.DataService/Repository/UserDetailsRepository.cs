using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIFullCRUDWithFile.DataService.Data;
using WebAPIFullCRUDWithFile.DataService.IRepository;
using WebAPIFullCRUDWithFile.Entities.Entities;

namespace WebAPIFullCRUDWithFile.DataService.Repository
{
    public class UserDetailsRepository: GenericRepository<UserDetailsEntity>, IUserDetailsRepository
    {
        public UserDetailsRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public List<UserDetailsEntity> GetUserDetails()
        {
            //var userDetails = (from user in _appDbContext.Users
            //                  join userdetail in _appDbContext.UserDetails on user.Id equals userdetail.UserId
            //                  select new UserDetailsEntity
            //                  {
            //                      UserId = userdetail.UserId,
            //                      Address = userdetail.Address
            //                  }).ToList();

            var userDetails = (from user in _appDbContext.Users
                               join userdetail in _appDbContext.UserDetails on user.Id equals userdetail.UserId
                               into gj from subDtl in gj.DefaultIfEmpty()
                               select new UserDetailsEntity
                               {
                                   UserId = user.Id,
                                   Address = subDtl.Address
                               }).ToList();
            return userDetails;
        }
    }
}
