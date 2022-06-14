using BlazorApp.Components.Enums;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components.Controls
{
    public partial class Notification
    {
        #region "Properties"
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Message { get; set; }

        [Parameter]
        public NotificationType Type { get; set; }

        [Parameter]
        public bool ShowNotification { get; set; }
        #endregion

        public Notification()
        {
            Title = string.Empty;
            Message = string.Empty;
            Type = NotificationType.Default;
            ShowNotification = false;
        }

        public void Show()
        {
            ShowNotification = true;
            StateHasChanged();
        }

        public async void Show(int interval)
        {
            await Task.Delay(interval);
            ShowNotification = true;
            StateHasChanged();
        }

        public void Hide()
        {
            ShowNotification = false;
        }

        public async void Hide(int interval)
        {
            await Task.Delay(interval);
            ShowNotification = false;
            StateHasChanged();
        }

        public void OnInfo(string Title, string Message)
        {
            this.Title = Title;
            this.Message = Message;
            Type = NotificationType.Information;
            ShowNotification = true;
            StateHasChanged();
        }

        public void OnSuccess(string Title, string Message)
        {
            this.Title = Title;
            this.Message = Message;
            Type = NotificationType.Success;
            ShowNotification = true;
            StateHasChanged();
        }

        public void OnWarning(string Title, string Message)
        {
            this.Title = Title;
            this.Message = Message;
            Type = NotificationType.Warning;
            ShowNotification = true;
            StateHasChanged();
        }

        public void OnError(string Title, string Message)
        {
            this.Title = Title;
            this.Message = Message;
            Type = NotificationType.Error;
            ShowNotification = true;
            StateHasChanged();
        }

        public void OnDefault(string Title, string Message)
        {
            this.Title = Title;
            this.Message = Message;
            Type = NotificationType.Default;
            ShowNotification = true;
            StateHasChanged();
        }
    }
}
