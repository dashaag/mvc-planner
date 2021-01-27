using Planner.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Planner.Entities.Initializers
{
    public class EntityInitializer : DropCreateDatabaseAlways<EFContext>
    {
        protected override void Seed(EFContext context)
        {
            context.Plans.Add(new Plan 
            { 
                Title = "Make a project",
                Description = "Project for art lesson",
                Date = "2020-29-01",
                IsPriority = false,
                Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ea/Van_Gogh_-_Starry_Night_-_Google_Art_Project.jpg/758px-Van_Gogh_-_Starry_Night_-_Google_Art_Project.jpg" });
            base.Seed(context);
        }
    }
}