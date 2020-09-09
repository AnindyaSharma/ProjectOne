using ProjectOne.Database;
using ProjectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext dbContext;

        public StudentRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Student Add(Student stu)
        {
            dbContext.Students.Add(stu);
            dbContext.SaveChanges();
            return stu;
        }

        public Student Delete(int Id)
        {
            Student stu = dbContext.Students.Find(Id);
            if (stu != null)
            {
                dbContext.Remove(stu);
                dbContext.SaveChanges();
            }

            return stu;
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return dbContext.Students;
        }

        public Student GetStudent(int Id)
        {
            return dbContext.Students.Find(Id);
        }

        public Student Update(Student studentchanges)
        {
            var stu = dbContext.Students.Attach(studentchanges);
            stu.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return studentchanges;
        }
    }
}
