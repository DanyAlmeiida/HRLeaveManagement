using FluentValidation;
using HRLeaveManagement.Application.Persistence.Contracts;

namespace HRLeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveRequestRepository repository;

        public CreateLeaveRequestDtoValidator(ILeaveRequestRepository repository)
        {
            this.repository = repository;
            Include(new ILeaveRequestDtoValidator(repository));
        }
    }
}
