using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIFullCRUDWithFile.DataService.IRepository;

namespace WebAPIFullCRUDWithFile.DataService.IConfiguration
{
    public interface IUnitOfWork
    {
        IUsersRepository Users { get; set; }
        IUserDetailsRepository UserDetails { get; set; }
        Task SaveChangesAsync();
    }
}
