//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClickInfo
    {
        public int id { get; set; }
        public Nullable<int> link_id { get; set; }
        public Nullable<System.DateTime> clicked_date { get; set; }
    
        public virtual Link Link { get; set; }
    }
}
