using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Exams.Models
{
    [Table("Exams")]
    public class Appointment
    {
        [Key]
        public int ExamId { get; set; }
        public DateTime ExamDate { get; set; }
        public string Student { get; set; }
    }
}