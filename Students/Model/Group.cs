using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Model
{
    public class Group
    {
        public int GroupId { get; set; }
        [StringLength(15)]
        [Index("IX_GroupName", IsUnique = true)]
        public string Name { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}