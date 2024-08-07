﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class HamburgerDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public List<Guid>? SelectedGarnitureIds { get; set; }
        public int Quantity { get; set; } = 1;
        public string? Size { get; set; }
        public List<MenuDto> MenuDtos { get; set; }
    }
}
