﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class UserDto : BaseDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public List<OrderDto> OrderDtos { get; set; }
    }
}
