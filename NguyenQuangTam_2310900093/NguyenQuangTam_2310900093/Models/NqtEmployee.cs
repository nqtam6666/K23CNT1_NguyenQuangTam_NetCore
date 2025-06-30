using System;
using System.Collections.Generic;

namespace NguyenQuangTam_2310900093.Models;

public partial class NqtEmployee
{
    public int NqtEmpId { get; set; }

    public string? NqtEmpName { get; set; }

    public string? NqtEmpLevel { get; set; }

    public DateOnly? NqtEmpStartDate { get; set; }

    public bool NqtEmpStatus { get; set; }
}
