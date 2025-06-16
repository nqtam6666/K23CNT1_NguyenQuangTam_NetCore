using System;
using System.Collections.Generic;

namespace NqtLesson09.Models;

public partial class NqtPublisher
{
    public int NqtPublisherId { get; set; }

    public string? NqtPublisherName { get; set; }

    public string? NqtPhone { get; set; }

    public string? NqtAddress { get; set; }

    public virtual ICollection<NqtBook> NqtBooks { get; set; } = new List<NqtBook>();
}
