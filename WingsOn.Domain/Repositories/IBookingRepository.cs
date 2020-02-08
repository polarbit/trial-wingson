﻿using System;
using System.Collections.Generic;
using System.Text;
using WingsOn.Domain.Entities;

namespace WingsOn.Domain.Repositories
{
    public interface IBookingRepository
    {
        Booking GetById(int id);

        void Save(Booking booking);
    }
}
