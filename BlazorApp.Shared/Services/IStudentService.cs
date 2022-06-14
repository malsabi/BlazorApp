using BlazorApp.Shared.Models;

namespace BlazorApp.Shared.Services
{
    public interface IStudentService
    {
        Task<StudentResponse?> CreateStudent(Student student);

        Task<StudentResponse?> GetStudent(string Id);

        Task<StudentResponse?> GetStudents();

        Task<StudentResponse?> ModifyStudent(string Id, Student student);

        Task<StudentResponse?> DeleteStudent(string id);
    }
}