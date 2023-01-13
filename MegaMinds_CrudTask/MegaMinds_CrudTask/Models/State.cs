
using System.ComponentModel.DataAnnotations;

namespace MegaMinds_CrudTask.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string  StateName { get; set; }
    }
}
