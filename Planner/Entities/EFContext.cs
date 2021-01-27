using Planner.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Planner.Entities
{
    public class EFContext: DbContext
    {
        public DbSet<Plan> Plans { get; set; }
    }
}