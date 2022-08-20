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
    public class UsersRepository: GenericRepository<UserModelEntity>, IUsersRepository
    {
        public UsersRepository(AppDbContext appDbContext): base(appDbContext)
        {}
    }
}
