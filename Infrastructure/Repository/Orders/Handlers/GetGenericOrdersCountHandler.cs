using Application.DTO.Response.Orders;
using Application.Extensions;
using Application.Service.Orders.Queries;
using Domain.Entities.Orders;
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
    public class GetGenericOrdersCountHandler(DataAccess.IDbContextFactory<AppDbContext>contextFactory):IRequestHandler<GetGenericOrdersCountQuery,GetOrdersCountResponseDTO>

    {
        public async Task<GetOrdersCountResponseDTO> Handle(GetGenericOrdersCountQuery request,CancellationToken cancellationToken)
        {
            using var dbContext = contextFactory.CreateDbContext();
            var list = new List<Order>();
            if (!request.IsAdmin)
            {
                list = await dbContext.Orders.AsNoTracking().Where(_ => _.ClientId.ToString() == request.UserId).ToListAsync(cancellationToken);

            }
            else
            {
                list = await dbContext.Orders.AsNoTracking().ToListAsync(cancellationToken);
            }
            int ProcessingCount = list.Count(_ => _.OrderState == OrderState.Processing);
            int DeliveredCount = list.Count(_ => _.OrderState == OrderState.Delivered);
            int CancelledCount = list.Count(_ => _.OrderState == OrderState.Cancelled);
            int DeliveringCount = list.Count(_ => _.OrderState == OrderState.Delivering);
            return new GetOrdersCountResponseDTO(ProcessingCount,DeliveringCount,DeliveredCount,CancelledCount);
        }
    }
}
