﻿using HRLeaveManagement.Application.DTOs.Common;
using System;

namespace HRLeaveManagement.Application.DTOs
{
    public class LeaveRequestDto : BaseDto
    {
        public EmployeeDto RequestingEmployee { get; set; }
        public string RequestingEmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }
        public DateTime DateActioned { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
        public EmployeeDto ApprovedBy { get; set; }
        public string ApprovedById { get; set; }
    }
}
