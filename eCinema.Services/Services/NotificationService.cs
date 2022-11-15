﻿using AutoMapper;
using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using eCinema.Services.Database;
using Microsoft.EntityFrameworkCore;

namespace eCinema.Services.Services
{
    public class NotificationService : BaseCRUDService<NotificationDto, Notification, NotificationSearchObject, NotificationInsertRequest, NotificationUpdateRequest>, INotificationService
    {
        public NotificationService(CinemaContext cinemaContext, IMapper mapper) : base(cinemaContext, mapper)
        {
        }

        public override IQueryable<Notification> AddFilter(IQueryable<Notification> query, NotificationSearchObject search)
        {
            var filteredQuery = query;
            if (!string.IsNullOrWhiteSpace(search.Title))
                filteredQuery = query.Where(x => x.Title != null && x.Title.ToLower().Contains(search.Title.ToLower()));
            if (search.AuthorId != Guid.Empty)
            {
                filteredQuery = query.Where(x => x.AuthorId == search.AuthorId);

            }
            if (!string.IsNullOrWhiteSpace(search.NotificationType) && search.NotificationType!="Svi")
                filteredQuery = query.Where(x => x.NotificationType != null && x.NotificationType.ToLower().Contains(search.NotificationType.ToLower()));

            return filteredQuery;

        }

        public override void BeforeInsert(NotificationInsertRequest insert,Notification entity)
        {
            entity.AuthorId = new Guid("C25954C5-F3A1-408D-FDCD-08DAC04D3E13");
            entity.Date = DateTime.Now;
        }

        public override void BeforeUpdate(Notification entity)
        {
            entity.Date = DateTime.Now;
        }

        public override IQueryable<Notification> AddInclude(IQueryable<Notification> query, NotificationSearchObject search)
        {
            if (search?.IncludeUsers is true)
            {
                query = query.Include(x => x.Author);
            }

            return query;
        }
    }
}
