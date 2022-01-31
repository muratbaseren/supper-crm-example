using System;
using System.ComponentModel.DataAnnotations;

namespace SupperCRMExample.Models
{
    public class CreateIssueModel
    {
        [Display(Name = "Özet")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [StringLength(400, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir.")]
        public string Summary { get; set; }

        [Display(Name = "Son Tarih")]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Atanan")]
        public int UserId { get; set; }
    }
    
    public class EditIssueModel
    {
        [Display(Name = "Özet")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [StringLength(400, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir.")]
        public string Summary { get; set; }

        [Display(Name = "Son Tarih")]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Durumu")]
        public bool Completed { get; set; }

        [Display(Name = "Atanan")]
        public int UserId { get; set; }
    }
}
