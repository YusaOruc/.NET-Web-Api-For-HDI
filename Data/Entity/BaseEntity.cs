using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Creator { get; set; }

        [Required]
        public int Updater { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public DateTime LastUpdateDate { get; set; }
    }
}
