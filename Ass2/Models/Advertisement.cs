using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ass2NET.Models
{
    public class Advertisement : Controller

    {
        [Key]
        public int AdvertisementId
        { 
            get;
            set; 
        }

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
        public string imageUrl
        {
            get;
            set;
        }

        public ICollection<CommunityAdvertisement> CommunityAdvertisements { get; set; }
    }
}
