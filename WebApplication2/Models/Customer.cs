using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a customer name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool isSubscribedTonewsletter { get; set; }
        public virtual MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        [Required(ErrorMessage = "Please check Membership Type id")]
        public byte MembershipTypeId { get; set; }
        [Display(Name = "Date of Birth")]
        [Min18yearsAsaMember]
        public DateTime? Birthday { get; set; }
     

    }
}