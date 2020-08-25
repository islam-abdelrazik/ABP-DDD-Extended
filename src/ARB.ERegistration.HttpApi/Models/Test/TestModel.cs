using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Volo.Abp.Data;

namespace ARB.ERegistration.Models.Test
{
    public class TestModel
    {
        [Required]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

    }
}