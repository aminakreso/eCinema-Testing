
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using eCinema.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCinema.Model.Constants;

namespace eCInema.Test.Data
{
    public static class ProjectionData
    {
        public static readonly List<Hall> Halls = new()
        {
            new Hall
            {
                Id = Guid.NewGuid(),
                Name = "Hall1",
            },
            new Hall
            {
                Id = Guid.NewGuid(),
                Name = "Hall2",
            },
        };

        public static readonly List<Price> Prices = new()
        {
            new Price
            {
                Id = Guid.NewGuid(),
                Name = "2D karta",
                Value = (decimal?)8.50,
            },
            new Price
            {
                Id = Guid.NewGuid(),
                Name = "3D karta",
                Value = (decimal?)9.50,
            },
        };
        
        public static readonly List<Projection> Projections = new()
        {
            new Projection
            {
                Id = Guid.NewGuid(),
                IsActive = true,
                Status = ProjectionStatus.Initialized,
                StateMachine = StateMachineConstants.DraftState,
                MovieId = MovieData.Movies[0]
                    .Id,
                DateTime = DateTime.Now,
                HallId = Halls[0].Id,
                PriceId = Prices[0].Id,
                ProjectionType = ProjectionTypes.EveningProjection,
            },
            new Projection
            {
                IsActive = true,
                Status = ProjectionStatus.Started,
                StateMachine = StateMachineConstants.ActiveState,
                MovieId = MovieData.Movies[1]
                    .Id,
                DateTime = DateTime.Now,
                HallId = Halls[1].Id,
                PriceId = Prices[1].Id,
                ProjectionType = ProjectionTypes.EveningProjection,
            },
            new Projection
            {
                Id = Guid.NewGuid(),
                IsActive = true,
                Status = ProjectionStatus.Initialized,
                StateMachine = StateMachineConstants.HiddenState,
                MovieId = MovieData.Movies[0].Id,
                DateTime = new DateTime(2022, 29, 11, 16, 30, 00),
                HallId = Halls[0].Id,
                PriceId = Prices[0].Id,
                ProjectionType = ProjectionTypes.EveningProjection,
            },
        };

        public static readonly ProjectionUpsertRequest ProjectionUpsertRequest = new ProjectionUpsertRequest()
        {
            Status = ProjectionStatus.Initialized,
            StateMachine = StateMachineConstants.HiddenState,
            MovieId = MovieData.Movies[0].Id,
            DateTime = new DateTime(2022, 29, 11, 16, 30, 00),
            HallId = Halls[0].Id,
            PriceId = Prices[0].Id,
            ProjectionType = ProjectionTypes.EveningProjection,
        };
    }
}
