﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SofaSea.Models;

namespace SofaSea.Dtos
{
    public class CustomerDto
    {
        public int ID { get; set; }

       [Required]
       [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public byte MembershipTypeId { get; set; }
        public MembershipTypeDto MembershipType { get; set; }

        // [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}