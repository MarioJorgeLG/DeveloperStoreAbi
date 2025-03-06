using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleCreatedEvent : INotification
    {
        public Guid SaleId { get; }

        public SaleCreatedEvent(Guid saleId)
        {
            SaleId = saleId;
        }
    }
}
