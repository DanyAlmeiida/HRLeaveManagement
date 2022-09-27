using HRLeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRLeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly HRLeaveManagementDbContext dbContext;
        public LeaveRequestRepository(HRLeaveManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approved)
        {
            leaveRequest.Approved = approved;
            dbContext.Entry(leaveRequest).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await dbContext.LeaveRequests
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            return leaveRequest;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var leaveRequests = await dbContext.LeaveRequests
                .Include(q => q.LeaveType)
                .ToListAsync();

            return leaveRequests;
        }
    }
}
