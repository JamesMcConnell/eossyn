namespace Eossyn.Infrastructure.DataContracts
{
    using System.Runtime.Serialization;

    [DataContract]
    public class WorldModel
    {
        [DataMember(Name = "worldId")]
        public string WorldId { get; set; }

        [DataMember(Name = "worldName")]
        public string WorldName { get; set; }
    }
}
