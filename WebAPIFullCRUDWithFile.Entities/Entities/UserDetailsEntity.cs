using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIFullCRUDWithFile.Entities.Entities
{
    public class UserDetailsEntity : BaseEntity
    {
        [ForeignKey("Users_UserDetails")]
        public int UserId { get; set; }
        public virtual UserModelEntity User { get; set; }

        public string Address { get; set; }
        public string NationalId { get; set; }
        public string ImageFile { get; set; }
    }
}
