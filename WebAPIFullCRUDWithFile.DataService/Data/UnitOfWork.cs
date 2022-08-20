using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIFullCRUDWithFile.DataService.IConfiguration;
using WebAPIFullCRUDWithFile.DataService.IRepository;
using WebAPIFullCRUDWithFile.DataService.Repository;

namespace WebAPIFullCRUDWithFile.DataService.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        AppDbContext _appDbContext;
        public IUsersRepository Users { get ; set; }
        public IUserDetailsRepository UserDetails { get; set; }
        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            Users = new UsersRepository(appDbContext);
            UserDetails = new UserDetailsRepository(appDbContext);
        }
        public async Task SaveChangesAsync()
        {
           await _appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
