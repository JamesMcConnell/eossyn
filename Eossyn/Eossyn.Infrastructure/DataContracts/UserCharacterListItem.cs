namespace Eossyn.Infrastructure.DataContracts
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UserCharacterListItem
    {
        [DataMember(Name = "name")]
        public string CharacterName { get; set; }

        [DataMember(Name = "race")]
        public string CharacterRace { get; set; }

        [DataMember(Name = "class")]
        public string CharacterClass { get; set; }

        [DataMember(Name = "worldId")]
        public string WorldId { get; set; }
    }
}
