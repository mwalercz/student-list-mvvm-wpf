using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Model
{
    public class Student
    {

        public int StudentId { get; set; }
        [Required]
        [Index("IX_StudentIndex", IsUnique = true)]
        [StringLength(15)]
        public string IndexNo { get; set; } = "";
        [Required]
        [StringLength(32)]
        public string FirstName { get; set; } = "";
        [Required]
        [StringLength(32)]
        public string LastName { get; set; } = "";
        public string BirthPlace { get; set; } = "";
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; } = DateTime.Today;
        [Required]
        public virtual Group Group { get; set; }
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public bool Equals(Student s)
        {
            return IndexNo.Equals(s.IndexNo) &&
                FirstName.Equals(s.FirstName) &&
                LastName.Equals(s.LastName) &&
                BirthPlace.Equals(s.BirthPlace) &&
                BirthDate.Equals(s.BirthDate) &&
                GroupId.Equals(s.GroupId);
        }
    }
}