using GoogleBooks.Application.Common.Interfaces;
using System;

namespace GoogleBooks.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
