using System;
using System.Collections.Generic;

namespace EmployeeRestAPI.Models.EF;

public partial class Employee
{
    public int Empno { get; set; }

    public string? Empname { get; set; }

    public string? Empdesignation { get; set; }

    public int? Empsalary { get; set; }

    public int? Deptno { get; set; }

    public string? Empispermenant { get; set; }

    public virtual Department? DeptnoNavigation { get; set; }
}
