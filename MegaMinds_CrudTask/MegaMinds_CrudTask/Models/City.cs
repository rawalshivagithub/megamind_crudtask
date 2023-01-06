
using System.ComponentModel.DataAnnotations;

namespace MegaMinds_CrudTask.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }

    }
}
