using Application.DTO.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Products.Commands.Products
{
    public record DeleteProductCommand(Guid Id) : IRequest<ServiceResponse>;
}
