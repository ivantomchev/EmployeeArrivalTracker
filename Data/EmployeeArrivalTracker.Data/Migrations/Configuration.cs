namespace EmployeeArrivalTracker.Data.Migrations
{

    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public sealed class Configuration : DbMigrationsConfiguration<EmployeeArrivalTrackerDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EmployeeArrivalTrackerDbContext context)
        {
            SeedData(context);
        }

        private void SeedData(EmployeeArrivalTrackerDbContext context)
        {
            if (!context.Employees.Any())
            {
                UriBuilder uri = new UriBuilder(Assembly.GetExecutingAssembly().CodeBase);
                string directoryName = Path.GetDirectoryName(Uri.UnescapeDataString(uri.Path));

                var json = File.ReadAllText(Path.Combine(directoryName, "employees.json"));

                var result = JsonConvert.DeserializeObject<List<EmployeeDTO>>(json);
                result = result.OrderBy(x => x.Id).ToList();
                result.ForEach(e =>
                {
                    e.Id = e.Id + 1;
                    e.ManagerId = e.ManagerId != null ? e.ManagerId + 1 : null;
                });

                var teams = result
                    .SelectMany(e => e.Teams)
                    .Distinct()
                    .Select(t => new Team
                    {
                        Name = t
                    })
                    .ToList();

                teams.ForEach(x => context.Teams.AddOrUpdate(t => t.Name, x));
                context.SaveChanges();

                var employees = result.Select(e => new Employee
                {
                    Age = e.Age,
                    Email = e.Email,
                    Id = e.Id,
                    ManagerId = e.ManagerId,
                    Name = e.Name,
                    Role = e.Role,
                    SurName = e.Surname,
                    Teams = context.Teams.Where(t => e.Teams.Contains(t.Name)).ToList()
                });

                employees.ToList().ForEach(x => context.Employees.Add(x));
                context.SaveChanges();
            }
        }
    }
}
