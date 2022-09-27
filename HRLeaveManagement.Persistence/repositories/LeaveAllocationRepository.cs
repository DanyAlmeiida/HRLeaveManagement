using HRLeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRLeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly HRLeaveManagementDbContext dbContext;
        public LeaveAllocationRepository(HRLeaveManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await dbContext.LeaveAllocations
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            return leaveAllocation;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            var leaveAllocations = await dbContext.LeaveAllocations
                .Include(q => q.LeaveType)
                .ToListAsync();

            return leaveAllocations;
        }
    }
}
