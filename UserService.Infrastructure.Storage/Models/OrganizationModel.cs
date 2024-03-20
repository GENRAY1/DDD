using System.ComponentModel.DataAnnotations;

namespace UserService.Infrastructure.Storage.Models;

public class OrganizationModel
{
    public Guid Id { get; set; }
    [MaxLength(100)] public string Name { get; set; } = null!;
    public List<UserModel> Users { get; set; } = [];
}