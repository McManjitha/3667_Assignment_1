using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace votingApp2.Models
{
    [Table("Option")]
    public class Options
    {
        [Key]
        public int option_id { get; set; }

        [Required]
        public int poll_id { get; set; }

        [Required]
        [StringLength(50)]
        public string option { get; set; }

        [Required]
        public int owner_id { get; set; }

        [Required]
        public int count { get; set; }

        //[ForeignKey("poll_id")]
        //public virtual Poll Poll { get; set; }
    }
}
