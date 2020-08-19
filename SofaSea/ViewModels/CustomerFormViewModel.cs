using SofaSea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SofaSea.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public int MyProperty { get; set; }

        public Customer Customer { get; set; }
    }
}