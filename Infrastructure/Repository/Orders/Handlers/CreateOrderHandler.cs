using Application.DTO.Response;
using Application.Extensions;
using Application.Service.Orders.Commands;
using Application.Service.Products.Commands.Categories;
using Application.Service.Products.Commands.Locations;
using Application.Service.Products.Commands.Products;
using Domain.Entities.Orders;
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
    public class CreateOrderHandler(DataAccess.IDbContextFactory<AppDbContext> contextFactory) : IRequestHandler<CreateOrderCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                using var dbContext = contextFactory.CreateDbContext();
                var product = await dbContext.Products.FirstOrDefaultAsync(_ => _.Id==request.Model.ProductId,cancellationToken:cancellationToken);
                var data = request.Model.Adapt<Order>();
                data.TotalAmount=product.Price * data.Quantity;
                data.OrderState = OrderState.Processing;
                data.Price = product.Price;
                dbContext.Orders.Add(data);
                await dbContext.SaveChangesAsync(cancellationToken);
                return new ServiceResponse(true,"Order placed succesfully");

            }
            catch (Exception ex)
            {
                return new ServiceResponse(true, ex.Message);
            }
        }
    }
}
