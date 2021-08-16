using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ass2NET.Models
{
    public class CommunityAdvertisement : Controller
    {
        public string CommunityId
        {
            get;
            set;
        }
        public int AdvertisementsId
        {
            get; 
            set;
        }

        public Community Community
        {
            get;
            set;
        }

        public Advertisement Advertisement 
        { 
            get;
            set;
        }

    }
}
