using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4NET.Models.ViewModels
{
    public class CommunityViewModel
    {

        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Community> communities { get; set; }
        public IEnumerable<CommunityMembership> CommunityMemberships { get; set; }


    }
}
