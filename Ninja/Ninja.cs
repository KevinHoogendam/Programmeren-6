//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ninja
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ninja
    {
        public Ninja()
        {
            this.Gear = new HashSet<Gear>();
        }
    
        public int ninjaId { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<Gear> Gear { get; set; }
    }
}