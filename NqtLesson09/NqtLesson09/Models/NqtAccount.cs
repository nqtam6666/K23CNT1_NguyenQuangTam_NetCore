using System;
using System.Collections.Generic;

namespace NqtLesson09.Models;

public partial class NqtAccount
{
    public string NqtAccountId { get; set; } = null!;

    public string NqtUsername { get; set; } = null!;

    public string? NqtPassword { get; set; }

    public string? NqtFullName { get; set; }

    public string? NqtPicture { get; set; }

    public string? NqtEmail { get; set; }

    public string? NqtAddress { get; set; }

    public string? NqtPhone { get; set; }

    public bool? NqtIsAdmin { get; set; }

    public bool? NqtActive { get; set; }

    public virtual ICollection<NqtOrderBook> NqtOrderBooks { get; set; } = new List<NqtOrderBook>();
}
