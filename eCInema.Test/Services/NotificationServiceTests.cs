namespace eCInema.Test.Services;

using AutoMapper;
using eCinema.Model.SearchObjects;
using eCinema.Services.Database;
using eCinema.Services.Profiles;
using eCinema.Services.Services;
using eCInema.Test.Data;

public sealed class NotificationServiceTests : IDisposable
{
    private readonly CinemaContext _databaseContextMock;
    private readonly NotificationService _systemUnderTest;

    public NotificationServiceTests()
    {
        _databaseContextMock = InMemoryDatabaseFactory.CreateInMemoryDatabase();

        var config = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>());

        var mapper = new Mapper(config);

        _systemUnderTest = new NotificationService(_databaseContextMock, mapper);
    }

    [Fact]
    public async Task GetAllAsync_WhenCalledWithNoFilterParameters_ReturnsListOfAllNotificaton()
    {
        // Arrange
        await _databaseContextMock.AddRangeAsync(NotificationData.Notifications);

        await _databaseContextMock.SaveChangesAsync();

        // Act
        var notificationList =
            await _systemUnderTest.GetAll();

        // Assert
        Assert.Equal(NotificationData.Notifications.Count, notificationList.Count());
    }

    [Fact]
    public async Task GetAllAsync_WhenCalledWithTitle_ShouldReturnSpecificNotification()
    {
        await _databaseContextMock.AddRangeAsync(NotificationData.Notifications);

        await _databaseContextMock.SaveChangesAsync();

        var searchTitle = NotificationData.Notifications[0].Title;

        // Act
        var client = await _systemUnderTest.GetAll(
            new NotificationSearchObject()
            {
                Title = searchTitle
            });

        // Assert
        Assert.Equal(
            _databaseContextMock.Notifications.Count(x => x.Title!.Contains(searchTitle!)),
            client.Count());
    }

    [Fact]
    public async Task GetAllAsync_WhenCalledWithNonExistingType_ShouldReturnEmpty()
    {
        // Arrange
        await _databaseContextMock.AddRangeAsync(NotificationData.Notifications);

        await _databaseContextMock.SaveChangesAsync();

        // Act
        var notifications = await _systemUnderTest
            .GetAll(
                new NotificationSearchObject()
                {
                    Title = "NonExistingName",
                });

        // Assert
        Assert.Empty(notifications);
    }

    [Fact]
    public async Task GetByIdAsync_WhenCalled_ReturnsNotificationWithGivenId()
    {
        // Arrange
        var notification = NotificationData.Notifications[0];
        await _databaseContextMock.AddRangeAsync(NotificationData.Notifications);

        await _databaseContextMock.SaveChangesAsync();

        // Act
        var notificationById = await _systemUnderTest.GetById(notification.Id);

        // Assert
        Assert.Equal(notification.Id, notificationById.Id);
    }

    [Fact]
    public async Task GetByIdAsync_WhenCalledWithInvalidNotificationId_ThrowsException()
    {
        // Arrange
        _databaseContextMock.AddRange(NotificationData.Notifications);
        await _databaseContextMock.SaveChangesAsync();

        // Assert
        await Assert.ThrowsAsync<Exception>(() =>
            _systemUnderTest.GetById(Guid.NewGuid()));
    }

    [Fact]
    public async Task InsertNotification_WhenCalled_AddsNewNotification()
    {
        // Arrange
        var listOfNotification = NotificationData.Notifications;
        _databaseContextMock.AddRange(listOfNotification);

        await _databaseContextMock.SaveChangesAsync();

        // Act
        await _systemUnderTest.Insert(NotificationData.notificationInsertRequest);

        // Assert
        var expectedRecordCount = listOfNotification.Count + 1;
        Assert.Equal(_databaseContextMock.Notifications.Count(), expectedRecordCount);
    }

    [Fact]
    public async Task InsertNotification_WhenCalledWithNoTitle_ThrowsException()
    {
        // Arrange
        var listOfNotification = NotificationData.Notifications;
        _databaseContextMock.AddRange(listOfNotification);

        await _databaseContextMock.SaveChangesAsync();

        // Assert
        await Assert.ThrowsAsync<Exception>(() =>
            _systemUnderTest.Insert(NotificationData.notificationInsertRequestInvalidTitle));
    }

    [Fact]
    public async Task UpdateNotification_WhenCalled_ReturnsUpdatedNotification()
    {
        // Arrange
        var notification = NotificationData.Notifications[0];
        _databaseContextMock.AddRange(NotificationData.Notifications);
        await _databaseContextMock.SaveChangesAsync();

        // Act
        var updatedNotification = await _systemUnderTest.Update(notification.Id, NotificationData.notificationUpdateRequest);

        Assert.Equal(notification.Id, updatedNotification.Id);
        Assert.Equal(notification.Title, updatedNotification.Title);
        Assert.Equal(notification.Content, updatedNotification.Content);
        Assert.Equal(notification.Picture, updatedNotification.Picture);
        Assert.Equal(notification.NotificationType, updatedNotification.NotificationType);
        Assert.Equal(notification.IsActive, updatedNotification.IsActive);
    }

    [Fact]
    public async Task UpdateNotification_WhenCalledWithInvalidType_ThrowsException()
    {
        // Arrange
        _databaseContextMock.AddRange(NotificationData.Notifications);
        await _databaseContextMock.SaveChangesAsync();

        // Assert
        await Assert.ThrowsAsync<Exception>(() =>
            _systemUnderTest.Update(NotificationData.Notifications[0].Id, NotificationData.NotificationUpdateRequestInvalidType));
    }

    [Fact]
    public async Task DeleteNotification_WhenCalled_RemovesNewNotification()
    {
        // Arrange
        var listOfNotification = NotificationData.Notifications;
        _databaseContextMock.AddRange(listOfNotification);

        await _databaseContextMock.SaveChangesAsync();

        // Act
        await _systemUnderTest.Delete(NotificationData.Notifications[0].Id);

        // Assert
        var expectedRecordCount = listOfNotification.Count - 1;
        Assert.Equal(_databaseContextMock.Notifications.Count(), expectedRecordCount);
    }

    [Fact]
    public async Task DeleteNotification_WhenCalledWithInvalidNotificationId_ThrowsException()
    {
        // Arrange
        _databaseContextMock.AddRange(NotificationData.Notifications);
        await _databaseContextMock.SaveChangesAsync();

        // Assert
        await Assert.ThrowsAsync<Exception>(() =>
            _systemUnderTest.Delete(Guid.NewGuid()));
    }

    public void Dispose()
    {
    }
}