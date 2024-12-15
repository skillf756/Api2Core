using System;
using System.Collections.Generic;

namespace Api2Core.Models;

public partial class RevisionApi
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public long? Mobile { get; set; }
}
