using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppointmentScheduler.Models
{
    public class AppointmentModel
    {
        [DisplayName("Patient's Full Name")]
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string patientName { get; set; }
        [DisplayName("Appointment Request Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime dateTime { get; set; }
        [DisplayName("Patient's approximate net worth")]
        [Required]
        [DataType(DataType.Currency)]
        public decimal patientNetWorth { get; set; }
        [DisplayName("Primary Doctor's Last Name")]
        [Required]
        public string doctorName { get; set; }
        [DisplayName("Patient's percieved level of pain (1 low - 10 high)")]
        [Required]
        [Range(1, 10)]
        public int painLevel { get; set; }
        [DisplayName("Patient's Street")]
        [Required]
        public string street { get; set; }
        [DisplayName("Patient's City")]
        [Required]
        public string city { get; set; }
        [DisplayName("Patient's ZIP")]
        [Required]
        public string zipcode { get; set; }
        [DisplayName("Patient's Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [DisplayName("Patient's Phone Number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }

        public AppointmentModel(string patientName, DateTime dateTime, decimal patientNetWorth, string doctorName, int painLevel,
            string street, string city, string zipcode, string email, string phone) 
        { 
            this.patientName = patientName;
            this.dateTime = dateTime;
            this.patientNetWorth = patientNetWorth;
            this.doctorName = doctorName;
            this.painLevel= painLevel;
            this.street = street;
            this.city = city;
            this.zipcode = zipcode;
            this.email = email;
            this.phone = phone;
        }

        public AppointmentModel() { }
    }
}
