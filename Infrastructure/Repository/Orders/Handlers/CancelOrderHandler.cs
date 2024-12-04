using Application.DTO.Response;
using Application.Extensions;
using Application.Service.Orders.Commands;
using Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Orders.Handlers
{
    public class CancelOrderHandler(DataAccess.IDbContextFactory<AppDbContext> contextFactory) : IRequestHandler<CancelOrderCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                using var dbContext = contextFactory.CreateDbContext();
                var order = await dbContext.Orders.Where(_ => _.Id == request.OrderId).FirstOrDefaultAsync(cancellationToken: cancellationToken);
                if (order == null)
                {
                    return new ServiceResponse(false, "Order not found");
                }
                order.OrderState = OrderState.Cancelled;
                await dbContext.SaveChangesAsync(cancellationToken);
                return new ServiceResponse(true, "Order cancelled successfully");

            }
            catch (Exception ex)
            {
                return new ServiceResponse(true, ex.Message);
            }
        }
    }
}
