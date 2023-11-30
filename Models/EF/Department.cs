using System;
using System.Collections.Generic;

namespace EmployeeRestAPI.Models.EF;

public partial class Department
{
    public int Deptno { get; set; }

    public string? Deptname { get; set; }

    public string? Deptlocation { get; set; }

    public string? Deptemail { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
