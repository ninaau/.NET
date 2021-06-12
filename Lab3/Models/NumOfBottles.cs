using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3NET.Models
{
    public class NumOfBottles
    {

        [Required]
        public int Bottles
        {
            get;
            set;
        }


    }
}
