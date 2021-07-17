using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5NET.Models
{

    public enum Question
    {
        Earth, 
        Computer

    }
    public class AnswerImage
    {
        [Required]
        [DisplayName("File Name")]
        public string FileName
        {
            get;
            set;
        }

        [Required]
        public int AnswerImageId
        {
            get;
            set;
        }

        [Required]
        [Url]
        public string Url
        {
            get;
            set;
        }
      
        [Required]
        public Question Question
        {
            get;
            set;
        }
    }
}
