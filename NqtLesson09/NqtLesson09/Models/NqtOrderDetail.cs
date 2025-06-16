using System;
using System.Collections.Generic;

namespace NqtLesson09.Models;

public partial class NqtOrderDetail
{
    public int NqtOrderDetailId { get; set; }

    public string? NqtOrderId { get; set; }

    public string? NqtBookId { get; set; }

    public int? NqtQuantity { get; set; }

    public int? NqtPrice { get; set; }

    public int? NqtTotalMoney { get; set; }

    public virtual NqtBook? NqtBook { get; set; }

    public virtual NqtOrderBook? NqtOrder { get; set; }
}
