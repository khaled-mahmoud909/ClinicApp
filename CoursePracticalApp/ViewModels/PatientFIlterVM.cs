using CoursePracticalApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePracticalApp.ViewModels
{
    public class PatientFilterVM
    {
        public int? Id { get; set; }

        public string? FullName { get; set; }

        public string? NationalId { get; set; }

        public string? PhoneNumber {  get; set; }

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 2;

        public int TotalCount { get; set; }

        public int PageCount => (int) Math.Ceiling((double) (TotalCount / PageSize));

    }
}
