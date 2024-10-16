﻿using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models
{
    public class Patients
    {
        [Key]
        public int PatientId { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Phone {  get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int EmergencyContact {  get; set; }
        public string BloodGroup {  get; set; }
        public DateTime RegistrationDate { get; set; }
        public string MedicalHistory { get; set; }
        public ICollection<Appointments> Appointments { get; set; }
        public ICollection<MedicalRecords> MedicalRecords { get; set; }


    }
}
