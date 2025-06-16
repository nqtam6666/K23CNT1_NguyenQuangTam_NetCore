using System;
using System.Collections.Generic;

namespace NqtLesson09.Models;

public partial class NqtCategory
{
    public int NqtCategoryId { get; set; }

    public string? NqtCategoryName { get; set; }

    public virtual ICollection<NqtBook> NqtBooks { get; set; } = new List<NqtBook>();
}
