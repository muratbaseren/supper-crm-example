namespace SupperCRMExample.WebApp.Models
{
    public class ModalInputViewModel
    {
        public bool IsReadonly { get; set; } = false;
        public string Description { get; set; } = "Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod.";
        public bool HasId { get; set; } = false;
    }

    public class ModalInputIssueViewModel: ModalInputViewModel
    {
        public bool HasCompletedField { get; set; } 
    }

    public class ModalInputLeadViewModel : ModalInputViewModel
    {
        public bool HasTypeField { get; set; }
    }
}
