using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DevInMotionApi.Models;

namespace DevInMotion.Api.Data
{
    public class DevInMotionApiContext : DbContext
    {
        public DevInMotionApiContext (DbContextOptions<DevInMotionApiContext> options)
            : base(options)
        {
        }

        public DbSet<DevInMotionApi.Models.Agreement> Agreement { get; set; }
    }
}
