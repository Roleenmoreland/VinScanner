using System.Threading.Tasks;
using VinScanner.Models.Repository;

namespace VinScanner.Interfaces
{
    public interface IScannerService
    {
        Task<VechileDetails> ScanVinNumber(string vinNumber, User user);

    }
}
