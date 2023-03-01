using Microsoft.CodeAnalysis.Options;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace votingApp2.Models
{
    [Table("Poll")]
    public class Poll
    {
        [Key]
        public int poll_id { get; set; }

        [Required]
        public int owner_id { get; set; }

        public ICollection<Options> Options { get; set; }

        //public virtual Votter Votter { get; set; }
    }
}
