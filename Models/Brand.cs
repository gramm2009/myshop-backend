using System;
using System.Collections.Generic;

namespace Supabase.Models;

public partial class Brand
{
    public long Id { get; set; }

    public string BrandName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
