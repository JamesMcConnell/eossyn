namespace Eossyn.Infrastructure.DataContracts
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UserConfigResponse
    {
        [DataMember(Name = "isAuthorized")]
        public bool IsAuthorized { get; set; }

        [DataMember(Name = "userConfig")]
        public UserConfig UserConfig { get; set; }
    }
}
