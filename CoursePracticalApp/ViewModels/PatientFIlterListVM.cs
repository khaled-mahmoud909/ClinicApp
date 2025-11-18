using CoursePracticalApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePracticalApp.Models
{
    public class PatientFilterListVM
    {
        public List<PatientVM> patientVMs { get; set; }

        public PatientFilterVM PatientFilterVM { get; set; } = new();
    }
}
