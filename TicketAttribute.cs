//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TicketManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class TicketAttribute
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int AssignedTo { get; set; }
        public string ExecutiveComment { get; set; }
        public int Status { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }
    }
}
