using SupperCRMExample.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupperCRMExample.Entities
{
    [Table("Issues")]
    public class Issue : EntityBase
    {
        [Required, StringLength(400)]
        public string Summary { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Completed { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; }
    }
}
