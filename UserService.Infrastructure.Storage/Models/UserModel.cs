using System.ComponentModel.DataAnnotations;

namespace UserService.Infrastructure.Storage.Models;

public class UserModel
{
    public Guid Id { get; set; }
    public Guid? OrganizationId { get; set; }
    public OrganizationModel? Organization { get; set; }
    [MaxLength(50)] public string FirstName { get; set; } = null!;
    [MaxLength(50)] public string LastName { get; set; } = null!;
    [MaxLength(50)] public string? Patronymic { get; set; }
    [MaxLength(50)] public string PhoneNumber { get; set; } = null!;
    [MaxLength(50)] public string Email { get; set; } = null!;
}