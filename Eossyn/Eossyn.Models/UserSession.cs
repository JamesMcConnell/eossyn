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
    
    public partial class UserSession
    {
        public System.Guid UserSessionId { get; set; }
        public System.Guid UserId { get; set; }
        public System.Guid CurrentUserCharacterId { get; set; }
        public System.Guid CurrentWorldId { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public bool IsActive { get; set; }
    }
}
