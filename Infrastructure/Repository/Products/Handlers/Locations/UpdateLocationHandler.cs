using Application.DTO.Response;
using Application.Service.Products.Commands.Categories;
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
    public class UpdateLocationHandler(DataAccess.IDbContextFactory<AppDbContext> contextFactory) : IRequestHandler<UpdateLocationCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                using var dbContext = contextFactory.CreateDbContext();
                var location = await dbContext.Locations.FirstOrDefaultAsync(_ => _.Id.Equals(request.LocationModel.Id), cancellationToken:cancellationToken);
                if (location != null)
                    return GeneralDbResponses.ItemNotFound(request.LocationModel.Name);

                dbContext.Entry(location).State = EntityState.Detached;
                var adaptData = request.LocationModel.Adapt(new Location());
                dbContext.Locations.Update(adaptData);
                await dbContext.SaveChangesAsync(cancellationToken);
                return GeneralDbResponses.ItemUpdate(request.LocationModel.Name);

            }
            catch (Exception e)
            {
                return new ServiceResponse(true, e.Message);
            }
        }
    }
}
