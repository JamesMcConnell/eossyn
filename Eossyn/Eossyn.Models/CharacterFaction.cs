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
    
    public partial class CharacterFaction
    {
        public CharacterFaction()
        {
            this.CharacterRaces = new HashSet<CharacterRace>();
        }
    
        public int CharacterFactionId { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<CharacterRace> CharacterRaces { get; set; }
    }
}