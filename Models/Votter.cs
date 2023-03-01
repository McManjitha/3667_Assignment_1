using System.ComponentModel.DataAnnotations;

namespace votingApp2.Models
{
    public class Votter
    {
        [Key]
        public int user_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string first_name { get; set; }

        [Required]
        [StringLength(50)]
        public string last_name { get; set; }

        [Required]
        [StringLength(10)]
        public string postal_code { get; set; }

        [Required]
        [StringLength(15)]
        public string telephone_number { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        [StringLength(50)]
        public string country { get; set; }

        //public ICollection<Poll> Poll { get; set; }
    }
}
