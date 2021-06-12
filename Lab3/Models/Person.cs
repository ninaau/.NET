using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3NET.Models
{
    public class Person
    {
        [Required]
        public string fName
        {
            get;
            set;
        }

        public string lName
        {
            get;
            set;
        }

        public int age
        {
            get;
            set;
        }

        public string email
        {
            get;
            set;
        }

        public int dofb
        {
            get;
            set;
        }

        public string descrpt
        {
            get;
            set;
        }
    }
}
