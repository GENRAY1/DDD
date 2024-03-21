using MassTransit;
using Microsoft.Extensions.Logging;
using RequestManager.Application.Abstractions.Dto;
using RequestManager.Application.Abstractions.Producers;
using Shared.Models;

namespace RequestManager.Infrastructure.Produce.Producers;

public class OrganizationProducer(IPublishEndpoint publishEndpoint, ILogger<OrganizationProducer> logger):IOrganizationProducer
{
    public void ProduceOrganizationCreate(OrganizationDto organizationDto)
    {
        //Логируем отправку
        logger.LogInformation("Отправка данных организации по шине: {Name} ",
            organizationDto.Name);

        //Публикуем сообщение
        publishEndpoint.Publish(new OrganizationCreated(organizationDto.Name));
        
    }
}