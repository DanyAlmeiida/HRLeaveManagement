using HRLeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.DTOs.LeaveRequest
{
    public class ChangeLeaveRequestDto : BaseDto
    {
        public bool? Approved { get; set; }
    }
}
