using System;
using System.Collections.Generic;

namespace Supabase.Models;

public partial class Category
{
    public long Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public float CategorySale { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
