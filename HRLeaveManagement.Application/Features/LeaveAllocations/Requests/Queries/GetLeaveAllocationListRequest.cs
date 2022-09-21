using HRLeaveManagement.Application.DTOs;
using MediatR;
using System.Collections.Generic;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>>
    {
    }
}
