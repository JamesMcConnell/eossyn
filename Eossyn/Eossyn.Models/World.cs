//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eossyn.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class World
    {
        public World()
        {
            this.UserCharacters = new HashSet<UserCharacter>();
        }
    
        public System.Guid WorldId { get; set; }
        public string WorldName { get; set; }
    
        public virtual ICollection<UserCharacter> UserCharacters { get; set; }
    }
}