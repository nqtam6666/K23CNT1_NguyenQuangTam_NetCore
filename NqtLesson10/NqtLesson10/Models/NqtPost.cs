using System;
using System.Collections.Generic;

namespace NqtLesson10.Models;

public partial class NqtPost
{
    public int NqtId { get; set; }

    public string? NqtTitle { get; set; }

    public string? NqtImage { get; set; }

    public string? NqtText { get; set; }

    public bool? NqtStatus { get; set; }
}
