namespace Eossyn.Core.Encryption
{
    public interface IHasherService
    {
        string ComputeHash(string valueToHash, string salt);
        string GenerateSalt();
    }
}
