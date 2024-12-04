using Application.DTO.Response.Orders;
using Application.Service.Orders.Queries;
using Domain.Entities.Orders;
using Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Orders.Handlers
{
    public class GetProductOrderByMonthHandler(DataAccess.IDbContextFactory<AppDbContext> contextFactory) : IRequestHandler<GetProductOrderedByMonthQuery, IEnumerable<GetProductOrderedByMonthsResponseDTO>>
    {
        public async Task<IEnumerable<GetProductOrderedByMonthsResponseDTO>> Handle(GetProductOrderedByMonthQuery request, CancellationToken cancellationToken)
        {
            using var dbContext = contextFactory.CreateDbContext();
            var orders = new List<Order>();
            var data = new List<GetProductOrderedByMonthsResponseDTO>();
            if (!string.IsNullOrEmpty(request.UserId))
            {
                orders = await dbContext.Orders.AsNoTracking().Where(_ => _.ClientId.ToString() == request.UserId).ToListAsync(cancellationToken);
            }
            else
            {
                orders = await dbContext.Orders.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
            }
            var selectOrdersWithin12Months = orders
                .Where(order => order.DateOrdered.Date >= DateTime.Today.AddMonths(-12))
                .GroupBy(order => new { Month=order.DateOrdered.Month})
                .ToList();
            foreach (var order in selectOrdersWithin12Months.OrderBy(_=>_.Key.Month))
            {
                data.Add(new GetProductOrderedByMonthsResponseDTO()
                {
                    MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(order.Key.Month),
                    TotalAmount = order.Sum(_ => _.TotalAmount),
                });
            }
            return data;

        }
    }

}
