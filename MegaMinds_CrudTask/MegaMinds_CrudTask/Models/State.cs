﻿
using System.ComponentModel.DataAnnotations;

namespace MegaMinds_CrudTask.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        public string  Name { get; set; }
    }
}
