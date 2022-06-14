namespace BlazorApp.Shared.Models
{
    public class StudentResponse
    {
        #region "Properties"
        public List<Student> Students { get; set; }

        public bool HasErrors { get; set; }

        public List<string> Errors { get; set; }
        #endregion

        public StudentResponse()
        {
            Students = new List<Student>();
            HasErrors = false;
            Errors = new List<string>();
        }
    }
}