using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class EntityBase : IEntityBase
{
    [Key]
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public DateTime UpdatedAt { get; private set; } = DateTime.Now;
    public bool IsDeleted { get; private set; } = false;
    public void Delete() => IsDeleted = true;
}