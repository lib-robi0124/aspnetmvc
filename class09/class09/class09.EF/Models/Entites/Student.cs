﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace class09.EF.Models.Entites
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        //[ForeignKey("FK_Student_CourseId")]
        public int ActiveCourseId { get; set; }
        public Course? ActiveCourse { get; set; }
    }
}
