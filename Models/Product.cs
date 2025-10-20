using System;
using System.Collections.Generic;

namespace Supabase.Models;

public partial class Product
{
    public long Id { get; set; }

    public long BrandId { get; set; }

    public long? CategoryId { get; set; }

    public float Price { get; set; }

    public string? ProductName { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual Category? Category { get; set; }
}
