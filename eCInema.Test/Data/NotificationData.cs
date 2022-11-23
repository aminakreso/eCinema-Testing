using eCinema.Model.Requests;
using eCinema.Model.Constants;
using eCinema.Services.Database;

namespace eCInema.Test.Data
{
    public static class NotificationData
    {
      public static readonly List<Notification> Notifications = new()
        {
            new Notification
            {
                Id = Guid.NewGuid(),
                IsActive = true,
                Title = "Neradni dan",
                AuthorId = UserData.Users[0].Id,
                Content = "Drzavni praznik",
                NotificationType = NotificationTypes.Holiday,
                Date = DateTime.Now
            },
            new Notification
            {
                Id = Guid.NewGuid(),
                IsActive = true,
                Title = "Neradni dan",
                AuthorId = UserData.Users[0].Id,
                Content = "Nova godina",
                NotificationType = NotificationTypes.Holiday,
                Date = DateTime.Now
            }

        };

      public static readonly NotificationInsertRequest notificationInsertRequest = new NotificationInsertRequest()
        {
            Title = "Bajram",
            Content = "Neradni dan povodom praznika",
            NotificationType = NotificationTypes.Holiday
        };

      public static readonly NotificationInsertRequest notificationInsertRequestInvalidTitle = new NotificationInsertRequest()
        {
            Title = null,
            Content = "Neradni dan povodom praznika",
            NotificationType = NotificationTypes.Holiday
        };

      public static readonly NotificationUpdateRequest notificationUpdateRequest = new NotificationUpdateRequest()
        {
            Title = "Bozic",
            Content = "Neradni dan povodom praznika",
            NotificationType = NotificationTypes.Holiday
        };

      public static readonly NotificationUpdateRequest NotificationUpdateRequestInvalidType = new NotificationUpdateRequest()
        {
            Title = "Bozic",
            Content = "Neradni dan povodom praznika",
            NotificationType = "NonExistingType"
        };
    }
}
