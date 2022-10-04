using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveAllocationRepository repository;
        private readonly IMapper mapper;
        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationDtoValidator(repository);
            var validationResult = await validator.ValidateAsync(request.LeaveAllocation);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var leaveAllocation = mapper.Map<LeaveAllocation>(request.LeaveAllocation);
            leaveAllocation = await repository.Add(leaveAllocation);

            return leaveAllocation.Id;
        }
    }
}
