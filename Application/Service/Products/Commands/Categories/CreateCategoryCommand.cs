using Application.DTO.Request.Products;
using Application.DTO.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Products.Commands.Categories
{
    public record CreateCategoryCommand(AddCategoryRequestDTO CategoryModel):IRequest<ServiceResponse>;
    
}
