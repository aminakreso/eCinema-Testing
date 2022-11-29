namespace eCInema.Test.Services
{
    using AutoMapper;
    using eCinema.Model.SearchObjects;
    using eCinema.Services.Database;
    using eCinema.Services.Profiles;
    using eCinema.Services.Services;
    using eCInema.Test.Data;

    public sealed class ProjectionServiceTests : IDisposable
    {
        private readonly CinemaContext _databaseContextMock;
        private readonly ProjectionService _systemUnderTest;

        public ProjectionServiceTests()
        {
            _databaseContextMock = InMemoryDatabaseFactory.CreateInMemoryDatabase();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>());

            var mapper = new Mapper(config);

            _systemUnderTest = new ProjectionService(_databaseContextMock, mapper);
        }

        [Fact]
        public async Task GetAllAsync_WhenCalledWithNoFilterParameters_ReturnsListOfAllProjections()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);

            await _databaseContextMock.SaveChangesAsync();

            // Act
            var projectionList =
                await _systemUnderTest.GetAll();

            // Assert
            Assert.Equal(ProjectionData.Projections.Count, projectionList.Count());
        }

        [Fact]
        public async Task GetAllAsync_WhenCalledWithOneFilterParameter_ShouldReturnSpecificProjection()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);

            await _databaseContextMock.SaveChangesAsync();

            var dateTime = ProjectionData.Projections[2].StartTime;
            var hall = ProjectionData.Projections[2].HallId;

            // Act
            var filteredProjections = await _systemUnderTest.GetAll(
                new ProjectionSearchObject()
                {
                    StartTime = dateTime
                });

            // Assert
            Assert.Equal(
                ProjectionData.Projections.Count(x => x.StartTime.Value == dateTime),
                filteredProjections.Count());
        }

        [Fact]
        public async Task GetAllAsync_WhenCalledWithMultipleFilterParameter_ShouldReturnSpecificProjection()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);

            await _databaseContextMock.SaveChangesAsync();

            var dateTime = ProjectionData.Projections[2].StartTime;
            var hall = ProjectionData.Projections[2].HallId;

            // Act
            var filteredProjections = await _systemUnderTest.GetAll(
                new ProjectionSearchObject()
                {
                    StartTime = dateTime,
                    HallId = hall
                });

            // Assert
            Assert.Equal(
                ProjectionData.Projections.Count(x => x.StartTime.Value == dateTime && x.HallId == hall),
                filteredProjections.Count());
        }

        [Fact]
        public async Task GetAllAsync_WhenCalledWithFilterParameter_ShouldReturnEmpty()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);

            await _databaseContextMock.SaveChangesAsync();

            // Act
            var filteredProjections = await _systemUnderTest.GetAll(
                new ProjectionSearchObject()
                {
                    StartTime = DateTime.Now
                });

            // Assert
            Assert.Equal(0,filteredProjections.Count());
        }

        [Fact]
        public async Task InsertProjectionsAsync_WhenCalled_Insert()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);

            await _databaseContextMock.SaveChangesAsync();

            // Act
            await _systemUnderTest.Insert(ProjectionData.ProjectionUpsertRequest);
            // Assert
            Assert.Equal(ProjectionData.Projections.Count() + 1, _databaseContextMock.Projections.Count());
        }

        [Fact]
        public async Task GetByIdAsync_WhenCalled_ReturnsProjectionWithGivenId()
        {
            // Arrange
            var projection = ProjectionData.Projections[0];
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);

            await _databaseContextMock.SaveChangesAsync();

            // Act
            var projectionById = await _systemUnderTest.GetById(projection.Id);

            // Assert
            Assert.Equal(projection.Id, projectionById.Id);
        }

        [Fact]
        public async Task GetByIdAsync_WhenCalledWithInvalidProjectionId_ThrowsException()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);
            await _databaseContextMock.SaveChangesAsync();

            // Assert
            await Assert.ThrowsAsync<Exception>(() =>
                _systemUnderTest.GetById(Guid.NewGuid()));
        }

        [Fact]
        public async Task UpdateProjectionAsync_WhenCalled_InvalidId_ThrowsException()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);
            await _databaseContextMock.SaveChangesAsync();

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _systemUnderTest.Update(Guid.NewGuid(),
                    ProjectionData.ProjectionUpsertRequest));
        }

        [Fact]
        public async Task SoftDeleteProjectionAsync_WhenCalled_RemovesProjection()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);

            await _databaseContextMock.SaveChangesAsync();

            // Act
            var softDeleteProjection = await _systemUnderTest.Delete(ProjectionData.Projections[0].Id);

            // Assert
            Assert.Equal(softDeleteProjection.IsActive, false);
        }

        [Fact]
        public async Task SoftDeleteProjectionAsync_WhenCalledWithStartedProjectionId_ThrowsException()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);

            await _databaseContextMock.SaveChangesAsync();

            await Assert.ThrowsAsync<Exception>(() =>
                _systemUnderTest.Delete(ProjectionData.Projections[3].Id));
        }

        [Fact]
        public async Task DeleteProjectionAsync_WhenCalledWithInvalidProjectionId_ThrowsException()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);
            await _databaseContextMock.SaveChangesAsync();

            // Assert
            await Assert.ThrowsAsync<Exception>(() =>
                _systemUnderTest.Delete(Guid.NewGuid()));
        }

        [Fact]
        public async Task ProjectionExistAsync_WhenCalledWithGuidEmpty_ReturnsFalse()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);

            await _databaseContextMock.SaveChangesAsync();

            // Act
            var allowedProjection = await _systemUnderTest.ProjectionExist(
                Guid.Empty, ProjectionData.ProjectionUpsertRequest);

            // Assert
            Assert.False(allowedProjection);
        }

        [Fact]
        public async Task ProjectionExistAsync_WhenCalledWithOverlappingStartTimeAndGuidEmpty_ReturnsTrue()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);

            await _databaseContextMock.SaveChangesAsync();

            // Act
            var allowedProjection = await _systemUnderTest.ProjectionExist(
                Guid.Empty, ProjectionData.ProjectionUpsertRequestInvalidStartTime);

            // Assert
            Assert.True(allowedProjection);
        }

        [Fact]
        public async Task ProjectionExistAsync_WhenCalledWithOverlappingEndTimeAndGuidEmpty_ReturnsTrue()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);

            await _databaseContextMock.SaveChangesAsync();

            // Act
            var allowedProjection = await _systemUnderTest.ProjectionExist(
                Guid.Empty, ProjectionData.ProjectionUpsertRequestInvalidEndTime);

            // Assert
            Assert.True(allowedProjection);
        }

        [Fact]
        public async Task ProjectionExistAsync_WhenCalledWithOverlappingStartAndEndTimeAndGuidEmpty_ReturnsTrue()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);

            await _databaseContextMock.SaveChangesAsync();

            // Act
            var allowedProjection = await _systemUnderTest.ProjectionExist(
                Guid.Empty, ProjectionData.ProjectionUpsertRequestInvalidStartEndTime);

            // Assert
            Assert.True(allowedProjection);
        }

        [Fact]
        public async Task ProjectionExistAsync_WhenCalledWithValidProjectionId_ReturnsFalse()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);

            await _databaseContextMock.SaveChangesAsync();

            // Act
            var allowedProjection = await _systemUnderTest.ProjectionExist(
                ProjectionData.Projections[0].Id, ProjectionData.ProjectionUpsertRequest);

            // Assert
            Assert.False(allowedProjection);
        }

        [Fact]
        public async Task ProjectionExistAsync_WhenCalledWithInvalidProjectionId_ThrowsException()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);

            await _databaseContextMock.SaveChangesAsync();

            // Assert
            await Assert.ThrowsAsync<Exception>(() =>
                _systemUnderTest.ProjectionExist(
                    Guid.NewGuid(), ProjectionData.ProjectionUpsertRequest));
        }

        // Test showing that we can update projection start and end time in range of his previous start and end time.
        [Fact]
        public async Task ProjectionExistAsync_WhenCalledWithOverlappingStartTimeAndValidProjectionId_ReturnsFalse()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);

            await _databaseContextMock.SaveChangesAsync();

            // Act
            var allowedProjection = await _systemUnderTest.ProjectionExist(
                ProjectionData.Projections[0].Id, ProjectionData.ProjectionUpsertRequestInvalidStartTime);

            // Assert
            Assert.False(allowedProjection);
        }

        // Test showing that we can't update projection start and end time in range of previous start and end time of other projections.
        [Fact]
        public async Task ProjectionExistAsync_WhenCalledWithOverlappingStartTimeAndValidProjectionId_ReturnsTrue()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);

            await _databaseContextMock.SaveChangesAsync();

            // Act
            var allowedProjection = await _systemUnderTest.ProjectionExist(
                ProjectionData.Projections[2].Id, ProjectionData.ProjectionUpsertRequestInvalidStartTime);

            // Assert
            Assert.True(allowedProjection);
        }

        public void Dispose()
        {
        }
    }
}
