using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIFullCRUDWithFile.Entities.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int Status { get; set; } = 1;
        [Column(TypeName = "datetime")]
        public DateTime InsertDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
    }
}
