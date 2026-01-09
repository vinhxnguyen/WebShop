using System;
using System.Collections.Generic;

namespace WebShop.Models;

public class ProductViewModel: Product
{
    public IFormFile SmallImageFile { get; set; }
    public IFormFile BigImageFile { get; set; }

}


