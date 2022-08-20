using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIFullCRUDWithFile.Entities.Entities;

namespace WebAPIFullCRUDWithFile.DataService.IRepository
{
    public interface IUsersRepository : IGenericRepository<UserModelEntity>
    {
    }
}
