using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a customer name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool isSubscribedTonewsletter { get; set; }
        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
        public DateTime? Birthday { get; set; }
    }
}