using System;
using System.Collections.Generic;

namespace DBFirstEFinAsp.netcoreDemo.Models;

public partial class View2
{
    public string CustomerId { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string? ContactName { get; set; }

    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? City { get; set; }
}
