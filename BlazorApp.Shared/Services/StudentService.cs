using BlazorApp.Shared.Models;
using BlazorApp.Shared.Globals;
using BlazorApp.Shared.Helpers;
using Newtonsoft.Json;

namespace BlazorApp.Shared.Services
{
    public class StudentService : IStudentService
    {
        public async Task<StudentResponse?> CreateStudent(Student student)
        {
            if (student == null)
            {
                return null;
            }
            else
            {
                string jsonContent = JsonConvert.SerializeObject(student);
                string response = await HttpHelper.PostRequest(API.Route, API.Student, jsonContent);
                return JsonConvert.DeserializeObject<StudentResponse>(response);
            }
        }

        public async Task<StudentResponse?> GetStudent(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return null;
            }
            else
            {
                string response = await HttpHelper.GetRequest(API.Route, API.Student, Id);
                return JsonConvert.DeserializeObject<StudentResponse>(response);
            }
        }

        public async Task<StudentResponse?> GetStudents()
        {
            string response = await HttpHelper.GetRequest(API.Route, API.Student);
            return JsonConvert.DeserializeObject<StudentResponse>(response);
        }

        public async Task<StudentResponse?> ModifyStudent(string id, Student student)
        {
            if (string.IsNullOrEmpty(id) || student == null)
            {
                return null;
            }
            else
            {
                string jsonContent = JsonConvert.SerializeObject(student);
                string response = await HttpHelper.PutRequest(API.Route, API.Student, id, jsonContent);
                return JsonConvert.DeserializeObject<StudentResponse>(response);
            }
        }

        public async Task<StudentResponse?> DeleteStudent(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            else
            {
                string response = await HttpHelper.DeleteRequest(API.Route, API.Student, id);
                return JsonConvert.DeserializeObject<StudentResponse>(response);
            }
        }
    }
}