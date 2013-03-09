namespace Eossyn.Infrastructure.DataContracts
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UserCharacterModel
    {
        [DataMember(Name = "charId")]
        public string CharacterId { get; set; }

        [DataMember(Name = "charName")]
        public string CharacterName { get; set; }

        [DataMember(Name = "charRace")]
        public string CharacterRace { get; set; }

        [DataMember(Name = "charClass")]
        public string CharacterClass { get; set; }

        [DataMember(Name = "charLevel")]
        public int CharacterLevel { get; set; }

        [DataMember(Name = "worldId")]
        public string WorldId { get; set; }
    }
}
