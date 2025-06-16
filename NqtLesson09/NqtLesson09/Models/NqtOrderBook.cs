using System;
using System.Collections.Generic;

namespace NqtLesson09.Models;

public partial class NqtOrderBook
{
    public string NqtOrderId { get; set; } = null!;

    public DateTime? NqtOrderDate { get; set; }

    public string? NqtAccountId { get; set; }

    public string? NqtReceiveAddress { get; set; }

    public string? NqtReceivePhone { get; set; }

    public DateTime? NqtOrderReceive { get; set; }

    public string? NqtNote { get; set; }

    public string? NqtStatus { get; set; }

    public virtual NqtAccount? NqtAccount { get; set; }

    public virtual ICollection<NqtOrderDetail> NqtOrderDetails { get; set; } = new List<NqtOrderDetail>();
}
