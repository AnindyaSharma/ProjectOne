using Microsoft.Extensions.Logging;
using ProjectOne.Database;
using ProjectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext dbContext;
        private readonly ILogger<DepartmentRepository> logger;

        public DepartmentRepository(AppDbContext dbContext,ILogger<DepartmentRepository>logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }
        public Department Add(Department department)
        {
            dbContext.Departments.Add(department);
            dbContext.SaveChanges();
            return department;
        }

        public Department Delete(int Id)
        {
            Department dep = dbContext.Departments.Find(Id);
            if (dep != null)
            {
                dbContext.Remove(dep);
                dbContext.SaveChanges();
            }
            
            return dep;
        }

        public IEnumerable<Department> GetAllDepartment()
        {
            return dbContext.Departments;
        }

        public Department GetDepartment(int Id)
        {
            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical Log");


            return dbContext.Departments.Find(Id);
        }

        public Department Update(Department departmentchanges)
        {
            var dep = dbContext.Departments.Attach(departmentchanges);
            dep.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return departmentchanges;
        }
    }
}
