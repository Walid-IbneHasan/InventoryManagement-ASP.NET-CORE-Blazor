using Application.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Products
{
    public static class GeneralDbResponses
    {
        public static ServiceResponse  ItemAlreadyExist(string  itemName)=> new(false, $"{itemName} already created");
        public static ServiceResponse ItemNotFound(string itemName) => new(false, $"{itemName} not found");
        public static ServiceResponse ItemCreated(string itemName) => new(false, $"{itemName} succesfully created");
        public static ServiceResponse ItemUpdate(string itemName) => new(false, $"{itemName} succesfully updated");
        public static ServiceResponse ItemDelete(string itemName) => new(false, $"{itemName} succesfully deleted");

    }
}
