using Application.Service.Orders.Queries;
using MediatR;

namespace WebUI.States.Administration
{
    public class UserActiveOrderCountState(IServiceProvider serviceProvider)
    {
        public int ProcessingCount { get; set; }
        public int DeliveringCount { get; set; }
        public int DeliveredCount { get; set; }
        public int CancelledCount { get; set; }
        public event Action? StateChanged;
        public async Task GetActiveOrdersCount(string userId)
        {
            using var scope = serviceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            var response = (await mediator.Send(new GetGenericOrdersCountQuery(userId, false)));
            ProcessingCount = response.Processing;
            DeliveringCount = response.Delivering;
            DeliveredCount = response.Delivered;
            CancelledCount = response.Cancelled;
            StateChanged?.Invoke();
        }
    }
}
