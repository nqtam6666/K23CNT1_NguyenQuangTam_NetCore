using System;
using System.Collections.Generic;

namespace NqtLesson09.Models;

public partial class NqtBook
{
    public string NqtBookId { get; set; } = null!;

    public string NqtTitle { get; set; } = null!;

    public string? NqtAuthor { get; set; }

    public int? NqtRelease { get; set; }

    public double? NqtPrice { get; set; }

    public string? NqtDescription { get; set; }

    public string? NqtPicture { get; set; }

    public int? NqtPublisherId { get; set; }

    public int? NqtCategoryId { get; set; }

    public virtual NqtCategory? NqtCategory { get; set; }

    public virtual ICollection<NqtOrderDetail> NqtOrderDetails { get; set; } = new List<NqtOrderDetail>();

    public virtual NqtPublisher? NqtPublisher { get; set; }
}
