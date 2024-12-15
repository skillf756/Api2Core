using System;
using System.Collections.Generic;

namespace Api2Core.Models;

public partial class TblapiEmployee
{
    public int Empid { get; set; }

    public string? EmpName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public long? Phone { get; set; }

    public int? Department { get; set; }
}
