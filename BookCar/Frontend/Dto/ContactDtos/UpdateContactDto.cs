﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.ContactDtos
{
    public class UpdateContactDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public string SendDate { get; set; }
    }
}
