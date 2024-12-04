using Application.DTO.Response.Products;
using Application.Service.Products.Queries.Products;
using Infrastructure.DataAccess;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Products.Handlers.Products
{
    public class GetProductByIdHandler(DataAccess.IDbContextFactory<AppDbContext>contextFactory):IRequestHandler<GetProductByIdQuery, GetProductResponseDTO>
    {
        public async Task<GetProductResponseDTO> Handle(GetProductByIdQuery request,CancellationToken cancellationToken)
        {
            using var dbContext = contextFactory.CreateDbContext();
            var product=await dbContext.Products.AsNoTracking().Include(c=>c.Category).Include(l=>l.Location).FirstOrDefaultAsync(_=>_.Id==request.Id, cancellationToken:cancellationToken);
            return new GetProductResponseDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Base64Image = product.Base64Image,
                CategoryId = product.CategoryId,
                LocationId = product.LocationId,
                Price = product.Price,
                DateAdded = product.DateAdded,
                Quantity = product.Quantity,
                SerialNumber = product.SerialNumber,
                Location = new GetLocationResponseDTO
                {
                    Id = product.Location.Id,
                    Name = product.Location.Name
                },
                Category = new GetCategoryResponseDTO
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name
                }
            };
        }
    }
}
