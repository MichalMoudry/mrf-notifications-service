namespace NotificationService.Database.Model.Domain;

/// <summary>
/// An abstract class describing basic characteristics of an entity in the system.
/// </summary>
public abstract class Entity
{
    public Guid Id { get; init; }

    public DateTime DateAdded { get; init; }

    public DateTime DateUpdated { get; init; }
}