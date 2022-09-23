using AutoMapper;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository repository;
        private readonly IMapper mapper;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await repository.Get(request.UpdateLeaveAllocation.Id);
            mapper.Map(request.UpdateLeaveAllocation, leaveAllocation);

            await repository.Update(leaveAllocation);

            return Unit.Value;
        }
    }
}
