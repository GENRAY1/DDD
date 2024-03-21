using RequestManager.Application.Abstractions.Dto;

namespace RequestManager.Application.Abstractions.Producers;

public interface IOrganizationProducer
{
    void ProduceOrganizationCreate(OrganizationDto organizationDto);
}