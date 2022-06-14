using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared.Models
{
    public class Student
    {
        #region "Properties"
        [Required]
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string College { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        [Required]
        public int NumberOfCourses { get; set; }
        [Required]
        public int TotalCreditHours { get; set; }
        [Required]
        public double GPA { get; set; }
        #endregion

        public Student()
        {
            Id = Guid.NewGuid().ToString();
            FirstName = string.Empty;
            LastName = string.Empty;
            College = string.Empty;
        }
    }
}