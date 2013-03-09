namespace Eossyn.Infrastructure.DataContracts
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UserConfig
    {
        [DataMember(Name = "username")]
        public string UserName { get; set; }

        [DataMember(Name = "currentCharacter")]
        public UserCharacterModel CurrentCharacter { get; set; }

        [DataMember(Name = "currentWorld")]
        public WorldModel CurrentWorld { get; set; }
    }
}
