namespace Eossyn.Core.Encryption
{
    public interface IHasherService
    {
        /// <summary>
        /// Computes a strong hash.
        /// </summary>
        /// <param name="valueToHash">The value to hash.</param>
        /// <param name="salt">The salt for the hash.</param>
        /// <returns>The hashed value.</returns>
        string ComputeHash(string valueToHash, string salt);
        /// <summary>
        /// Generates a random salt value.
        /// </summary>
        /// <returns>A random salt value.</returns>
        string GenerateSalt();
    }
}
