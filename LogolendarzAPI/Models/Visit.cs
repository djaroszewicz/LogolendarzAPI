using System.ComponentModel.DataAnnotations;

namespace LogolendarzAPI.Models
{
    public class Visit
    {
        [Key]
        public int VisitId { get; set; }
        [Required]
        public int SpeechTherId { get; set; }
        [Required]
        public int PatientId { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime Created { get; set; }

    }
}
