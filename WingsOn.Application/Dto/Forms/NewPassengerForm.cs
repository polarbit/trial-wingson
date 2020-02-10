﻿using System;
using WingsOn.Api.Application.Dtos.Enums;

namespace WingsOn.Api.Application.Dtos.Forms
{
    public class NewPassengerForm
    {
        public string Name { get; set; }

        public DateTime DateBirth { get; set; }

        public Gender Gender { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
    }
}