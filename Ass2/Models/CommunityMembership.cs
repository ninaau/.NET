using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ass2NET.Models
{
    public class CommunityMembership
    {

        public int StudentsId { get ; set; }


        public string CommunitiesId { get; set; }

        public Student Student { get ; set; }

        public Community Community { get; set; }
    }
}
