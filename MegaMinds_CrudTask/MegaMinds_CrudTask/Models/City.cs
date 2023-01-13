
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMinds_CrudTask.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        [Required]
        [Display(Name = "State")]
        public int StateId { get; set; }
        [ForeignKey(nameof(StateId))]
        public virtual State State { get; set; }

    }
}
