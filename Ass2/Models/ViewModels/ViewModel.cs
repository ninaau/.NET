using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ass2NET.Models.ViewModels
{
    public class ViewModel
    {

        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Community> communities { get; set; }
        public IEnumerable<CommunityMembership> CommunityMemberships { get; set; }
        public IEnumerable<Advertisement> Advertisements { get; set; }
        public IEnumerable<CommunityAdvertisement> CommunityAdvertisements { get; set; }


    }
}
