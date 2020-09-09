using ProjectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Repository
{
    public interface IStudentRepository
    {
        Student Add(Student student);
        IEnumerable<Student> GetAllStudent();
        Student GetStudent(int Id);
        Student Update(Student studentchanges);
        Student Delete(int Id);
    }
}
