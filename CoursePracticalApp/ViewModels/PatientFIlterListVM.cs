using CoursePracticalApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePracticalApp.ViewModels
{
    public class PatientFilterListVM
    {
        public List<PatientVM> patientVMs { get; set; } = new List<PatientVM>();

        public PatientFilterVM PatientFilterVM { get; set; } = new();
    }
}
