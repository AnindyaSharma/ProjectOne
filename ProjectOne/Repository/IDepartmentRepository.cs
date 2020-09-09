using ProjectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Repository
{
    public interface IDepartmentRepository
    {
        Department Add(Department department);
        IEnumerable<Department> GetAllDepartment();
        Department GetDepartment(int Id);
        Department Update(Department departmentchanges);
        Department Delete(int Id);

    }
}
