using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinScanner.Data;
using VinScanner.Interfaces;
using VinScanner.Models.Repository;

namespace VinScanner.Repository
{
    public class VechileDetailsRepository : IVechileDetailsRepository
    {
        private readonly VinScannerContext context;
        public VechileDetailsRepository()
        {
            context = new VinScannerContext();
        }

        /// <summary>
        /// Adds new vechile details
        /// </summary>
        /// <param name="vechileDetails"></param>
        /// <returns></returns>
        public async Task<VechileDetails> AddAsync(VechileDetails vechileDetails)
        {
            if (vechileDetails != null)
            {
                vechileDetails.Vin.ToLower();
                var result = await context.VechileDetails.AddAsync(vechileDetails);
                return result.Entity;
            }
            throw new ApplicationException("Cannot add add vechile details");
        }

        /// <summary>
        /// Returns the vechile details based on the vin number
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        public async Task<VechileDetails> Get(string vin)
        {
            if (!string.IsNullOrWhiteSpace(vin))
            {
                vin.ToLower();
                var result = await context.VechileDetails.FirstOrDefaultAsync(v => v.Vin == vin);
                return result;
            }
            return null;
        }
    }
}
