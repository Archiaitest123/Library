using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Mappings;

public static class NotificationMappings
{
    public static NotificationDto ToDto(this Notification notification)
    {
        return new NotificationDto
        {
            Id = notification.Id,
            CustomerId = notification.CustomerId,
            Title = notification.Title,
            Message = notification.Message,
            Type = notification.Type,
            IsRead = notification.IsRead,
            ReadAt = notification.ReadAt,
            CreatedAt = notification.CreatedAt
        };
    }

    public static Notification ToEntity(this CreateNotificationDto dto)
    {
        return new Notification
        {
            Id = Guid.NewGuid(),
            CustomerId = dto.CustomerId,
            Title = dto.Title,
            Message = dto.Message,
            Type = dto.Type,
            IsRead = false,
            SentAt = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow
        };
    }
}
