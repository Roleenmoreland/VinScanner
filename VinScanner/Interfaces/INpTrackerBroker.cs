using System.Threading.Tasks;
using VinScanner.Models;

namespace VinScanner.Interfaces
{
    public interface INpTrackerBroker
    {
        Task<VechileCheckReportResponse> VechileCheckReport(string vinNumber);
    }
}
