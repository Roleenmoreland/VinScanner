using System.Threading.Tasks;
using VinScanner.Models.Repository;

namespace VinScanner.Interfaces
{
    public interface IVechileDetailsRepository
    {
        Task<VechileDetails> Get(string vin);
        Task<VechileDetails> AddAsync(VechileDetails vechileDetails);

    }
}
