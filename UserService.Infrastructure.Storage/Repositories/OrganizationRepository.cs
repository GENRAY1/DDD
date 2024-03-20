using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserService.Domain.Abstractions.Repositories;
using UserService.Domain.OrganizationAggregate;
using UserService.Infrastructure.Storage.Context;
using UserService.Infrastructure.Storage.Mappers.AggregateMappers;
using UserService.Infrastructure.Storage.Mappers.ModelMappers;


namespace UserService.Infrastructure.Storage.Repositories;

public class OrganizationRepository:IOrganizationRepository
{
    private readonly ApplicationDbContext _context;
    public OrganizationRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Organization?> GetAsync(Guid id)
    {
        var organizationModel = await _context.Organizations.FirstOrDefaultAsync(u => u.Id == id);
        return organizationModel == null ? null : OrganizationMapper.Map(organizationModel);
    }

    public async Task UpdateAsync(Organization organization)
    {
        var organizationModel = await _context.Organizations.FirstOrDefaultAsync(u => u.Id == organization.Id);
        if (organizationModel == null) return;
        
        var org = OrganizationModelMapper.Map(organization);
        _context.Organizations.Update(org);
        await _context.SaveChangesAsync();
        
    }

    public async Task AddAsync(Organization organization)
    {
        var organizationModel = OrganizationModelMapper.Map(organization);
        _context.Organizations.Add(organizationModel);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Organization>> FindAsync(int skip, int take)
    {
        var organizations = await _context.Organizations
            .OrderBy(o => o.Id)
            .Skip(skip)
            .Take(take)
            .ToListAsync();

        return organizations
            .Select(o => OrganizationMapper.Map(o))
            .ToList();
    }
}