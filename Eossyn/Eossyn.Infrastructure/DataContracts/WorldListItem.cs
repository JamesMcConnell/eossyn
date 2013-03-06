namespace Eossyn.Infrastructure.DataContracts
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class WorldListItem
    {
        [DataMember(Name = "worldId")]
        public Guid WorldId { get; set; }

        [DataMember(Name = "worldName")]
        public string WorldName { get; set; }
    }
}
