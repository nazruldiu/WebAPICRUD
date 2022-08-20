using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIFullCRUDWithFile.Entities.Entities
{
    public class UserModelEntity: BaseEntity
    {
        [Column(TypeName = "nvarchar(100)")]
        public string Username { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        public virtual ICollection<UserDetailsEntity> UserDetailsEntities { get; set; }
    }
}
