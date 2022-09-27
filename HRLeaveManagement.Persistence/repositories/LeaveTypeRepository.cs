using HRLeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly HRLeaveManagementDbContext dbContext;
        public LeaveTypeRepository(HRLeaveManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
