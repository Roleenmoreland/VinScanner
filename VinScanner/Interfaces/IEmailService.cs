using System.Threading.Tasks;

namespace VinScanner.Interfaces
{
    public interface IEmailService
    {
        Task<bool> Send(string to, string template, string[] replacements);
    }
}