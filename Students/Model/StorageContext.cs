using System.Data.Entity;

namespace Students.Model
{
    public class StorageContext: DbContext
    {
        public StorageContext() : base("StudentsList")
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}