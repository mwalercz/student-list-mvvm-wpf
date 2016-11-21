using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Students.Model
{
    public class Storage
    {
        public List<Student> GetStudents()
        {
            using (var db = new StorageContext())
                return db.Students
                    .Include(nameof(Group))
                    .ToList();
        }

        public List<Student> Filter(int groupId, string birthPlace)
        {
            if (groupId != 0)
                return FilterByBirthPlaceAndGroup(groupId, birthPlace);
            else
                return FilterByBirthPlace(birthPlace);
        }

        public List<Student> FilterByBirthPlaceAndGroup(int groupId, string birthPlace)
        {
            using (var db = new StorageContext())
            {
                var q = (from student in db.Students
                         join gr in db.Groups on student.GroupId equals gr.GroupId
                         where student.BirthPlace.Contains(birthPlace)
                         where student.GroupId == groupId
                         select student).Include(nameof(Group));
                return q.ToList();
            }
        }
        public List<Student> FilterByBirthPlace(string birthPlace)
        {
            using (var db = new StorageContext())
            {
                var q = (from student in db.Students
                         join gr in db.Groups on student.GroupId equals gr.GroupId
                         where student.BirthPlace.ToLower().Contains(birthPlace)
                         select student).Include(nameof(Group));
                return q.ToList();
            }
        }

        public Student GetStudentById(int id)
        {
            using (var db = new StorageContext())
            {
                var student = db.Students.Find(id);
                if (student == null) return new Student();
                else return student;
            }
        }

        public List<Group> GetGroups()
        {
            using (var db = new StorageContext())
                return db.Groups.ToList();
        }
  
        public void CreateStudent(Student student)
        {
            using (var db = new StorageContext())
            {
                var group = db.Groups.Find(student.GroupId);
                var newStud = new Student
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    BirthDate = student.BirthDate,
                    BirthPlace = student.BirthPlace,
                    GroupId = group.GroupId,
                    IndexNo = student.IndexNo,
                };
                db.Students.Add(newStud);
                db.SaveChanges();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (var db = new StorageContext())
            {
                
                var group = db.Groups.Find(student.GroupId);
                student.GroupId = group.GroupId;
                db.Students.Attach(student);
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void RemoveStudent(Student student)
        {
            using (var db = new StorageContext())
            {
                var original = db.Students.Find(student.StudentId);
                if (original != null)
                {
                    db.Students.Remove(original);
                    db.SaveChanges();
                }
            }
        }

    }
}