using Application.DTO.Response;
using Application.Service.Products.Commands.Locations;
using Domain.Entities.Products;
using Infrastructure.DataAccess;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Products.Handlers.Categories
{
    public class DeleteLocationHandler(DataAccess.IDbContextFactory<AppDbContext> contextFactory) : IRequestHandler<DeleteLocationCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                using var dbContext = contextFactory.CreateDbContext();
                var data = await dbContext.Locations.FirstOrDefaultAsync(_ => _.Id.Equals(request.Id));
                if (data == null)
                    return GeneralDbResponses.ItemNotFound("Location");


                dbContext.Locations.Remove(data);
                await dbContext.SaveChangesAsync(cancellationToken);
                return GeneralDbResponses.ItemDelete(data.Name);

            }
            catch (Exception e)
            {
                return new ServiceResponse(true, e.Message);
            }
        }
    }
}
