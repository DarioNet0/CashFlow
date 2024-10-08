namespace CashFlow.Domain.Security.Cryptography
{
    public interface IPasswordEncripter
    {
        string Encrypt(string password);
        bool verifyPassword(string password, string passwordHash);
    }
}
