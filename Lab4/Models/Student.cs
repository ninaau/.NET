using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4NET.Models
{
    public class Student
    {

        [Required]
        public int ID { get; set; }

        [StringLength(50)]
        [Display(Name = "LastName")]
        [Required]
        public string LastName { get; set; }

        [StringLength(50)]
        [Display(Name = "FirstName")]
        [Required]
        public string FirstName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        [Required]
        public DateTime EnrollmentDate { get; set; }

        [StringLength(100)]
        [Display(Name = "FullName")]
        [Required]
        public string FullName {

                get
                {

                return LastName + ", " + FirstName;

                }

             }
        public ICollection<CommunityMembership> CommunityMemberships { get; set; }
    }
}
