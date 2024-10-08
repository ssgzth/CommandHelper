﻿using System.ComponentModel.DataAnnotations;

namespace CommandHelper.Models
{
    public class Command
    {
        [Key]
        public  int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? HowTo { get; set; }
        [Required]
        public string? Line { get; set; }
        [Required]
        public string?  Platform { get; set; }
    }
}
