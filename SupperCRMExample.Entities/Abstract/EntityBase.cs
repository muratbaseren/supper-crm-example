using System.ComponentModel.DataAnnotations;

namespace SupperCRMExample.Entities.Abstract
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
