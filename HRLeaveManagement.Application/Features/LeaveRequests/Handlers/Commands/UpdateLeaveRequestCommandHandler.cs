using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository repository;
        private readonly IMapper mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await repository.Get(request.Id);

            var validator = new UpdateLeaveRequestDtoValidator(repository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequest);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            if (request.LeaveRequest != null)
            {
                mapper.Map(request.LeaveRequest, leaveRequest);

                await repository.Update(leaveRequest);
                
            }
            else if (request.ChangeLeaveRequestApproval != null)
            {
                await repository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApproval.Approved);
            }

            return Unit.Value;
        }
    }
}
