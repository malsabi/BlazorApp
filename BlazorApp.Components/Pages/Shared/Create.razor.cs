using BlazorApp.Shared.Models;
using BlazorApp.Shared.Services;
using BlazorApp.Components.Controls;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp.Components.Pages.Shared
{
    public partial class Create : ComponentBase
    {
        #region "Properties"
        public Notification? Notification { get; set; }
        public Student Student { get; set; }
        public bool IsLoading { get; set; }
        #endregion

        public Create()
        {
            Notification = null!;
            Student = new Student();
            IsLoading = false;
        }

        public Notification GetNotification()
        {
            return Notification ?? new Notification();
        }

        public async Task OnSubmitHandler(EditContext editContext)
        {
            if (IsLoading == false)
            {
                IsLoading = true;
                bool formIsValid = editContext.Validate();
                if (formIsValid)
                {
                    StudentResponse? studentResponse = await StudentService.CreateStudent(Student);
                   
                    if (studentResponse != null)
                    {
                        if (studentResponse.HasErrors == false)
                        {
                            GetNotification().OnSuccess("Create Student", string.Format("Student {0}, successfully created on {1}", Student.FirstName, DateTime.Now));
                        }
                        else
                        {
                            GetNotification().OnError("Create Student", string.Join("\n", studentResponse.Errors));
                        }
                    }
                    else
                    {
                        GetNotification().OnError("Create Student", "No response from server.");
                    }
                }
                else
                {
                    GetNotification().OnError("Create Student", "Form is not valid");
                }
                GetNotification().Hide(3000);
                IsLoading = false;
            }
            else
            {
                return;
            }
        }
    }
}