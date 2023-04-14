using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Products.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<GetProductDto>>> GetAllProducts();
        Task<ServiceResponse<GetProductDto>> GetProductById(int id);
        Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto newProduct);
        Task<ServiceResponse<GetProductDto>> UpdateProduct(UpdateProductDto updatedProduct);
        Task<ServiceResponse<List<GetProductDto>>> DeleteProductById(int id);


        //Reviews
        Task<ServiceResponse<List<GetReviewDto>>> GetAllReviews(); //TODO Añadir Review DTO

    
    }
}