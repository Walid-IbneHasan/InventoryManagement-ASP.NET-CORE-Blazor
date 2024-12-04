using Application.DTO.Response;
using Application.Service.Products.Commands.Locations;
using Application.Service.Products.Commands.Products;
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
    public class DeleteProductHandler(DataAccess.IDbContextFactory<AppDbContext> contextFactory) : IRequestHandler<DeleteProductCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                using var dbContext = contextFactory.CreateDbContext();
                var data = await dbContext.Products.FirstOrDefaultAsync(_ => _.Id.Equals(request.Id),cancellationToken:cancellationToken);
                if (data == null)
                    return GeneralDbResponses.ItemNotFound("Location");


                dbContext.Products.Remove(data);
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
