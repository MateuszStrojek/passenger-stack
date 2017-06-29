using System;
using System.Collections.Generic;
using Passenger.Core.Domain;
using System.Linq;
using Passenger.Core.Repositories;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryDriverRepository : IDriverRepository
    {
        private static ISet<Driver> _drivers = new HashSet<Driver>();
        public async Task AddAsync(Driver driver)
        {
            _drivers.Add(driver);
            await Task.CompletedTask;
        }

        public async Task<Driver> GetAsync(Guid userId)
        {
            return await Task.FromResult(_drivers.Single(x => x.UserId == userId));
        }

        public async Task<IEnumerable<Driver>> GetAllAsync()
        {
            return await Task.FromResult(_drivers);
        }

        public async Task UpdateAsync(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}