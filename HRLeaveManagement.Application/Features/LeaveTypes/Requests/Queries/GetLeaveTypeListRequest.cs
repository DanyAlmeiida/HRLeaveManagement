using HRLeaveManagement.Application.DTOs;
using MediatR;
using System.Collections.Generic;

namespace HRLeaveManagement.Application.Features.LeaveType.Requests.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
    {
    }
}
