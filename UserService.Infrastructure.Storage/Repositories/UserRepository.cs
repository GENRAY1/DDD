using Microsoft.EntityFrameworkCore;
using UserService.Domain.Abstractions.Repositories;
using UserService.Domain.UserAggregate;
using UserService.Infrastructure.Storage.Context;
using UserService.Infrastructure.Storage.Mappers.AggregateMappers;
using UserService.Infrastructure.Storage.Mappers.ModelMappers;
using UserService.Infrastructure.Storage.Models;

namespace UserService.Infrastructure.Storage.Repositories;

public class UserRepository:IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<User?> GetAsync(Guid id)
    {
        var userModel = await _context.Users
            .AsNoTracking()
            .Include(u => u.Organization)
            .FirstOrDefaultAsync(u => u.Id == id);
        
        return userModel == null ? null : UserMapper.Map(userModel);
    }
    

    public async Task UpdateAsync(User user)
    {
        var userModel = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == user.Id);
        if (userModel == null) return;
        
        var u = UserModelMapper.Map(user, userModel);
        _context.Users.Update(u);
        await _context.SaveChangesAsync();
        
    }

    public async Task AddAsync(User user)
    {
        var newUserModel = new UserModel{Id = user.Id};
        var userModel = UserModelMapper.Map(user, newUserModel);
        _context.Users.Add(userModel);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<User>> FindAsync(Guid? organizationId, int skip, int take)
    {
        var users = await _context.Users.Where(u => u.OrganizationId == organizationId)
            .OrderBy(u => u.Id)
            .Skip(skip)
            .Take(take)
            .ToListAsync();

        return users.Select(u => UserMapper.Map(u)).ToList();
    }

    public async Task<ICollection<User>> FindWithoutOrganizationAsync(int skip, int take)
    {
        var users = await _context.Users.Where(u => u.OrganizationId == null)
            .OrderBy(u => u.Id)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
        return users.Select(u => UserMapper.Map(u)).ToList();
    }
}