﻿using System.ComponentModel.DataAnnotations;

namespace CommandHelper.Dtos
{
    public class CommandReadDto
    {

        public int Id { get; set; }

        public string? HowTo { get; set; }
        public string? Line { get; set; }

        

    }
}
