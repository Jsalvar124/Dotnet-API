using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Products.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        //Constructor
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        //GET list of all products
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetProductDto>>>> Get() //returns a list of products
        {
            var response = await _productService.GetAllProducts();
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        
        //GET product by id
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> GetSingle(int id) //returns a list of products
        {
            var response = await _productService.GetProductById(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        //POST add new product
        [HttpPost("Add")]
        public async Task<ActionResult<ServiceResponse<List<GetProductDto>>>> AddProduct(AddProductDto newProduct) //returns a list of products
        {
            return Ok(await _productService.AddProduct(newProduct));
        }

        //PUT add new product
        [HttpPut("Update")]
        public async Task<ActionResult<ServiceResponse<List<GetProductDto>>>> UpdateProduct(UpdateProductDto updatedProduct) //returns a list of products
        {
            var response = await _productService.UpdateProduct(updatedProduct);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        //DELETE product by id
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> DeleteProduct(int id)
        {
            var response = await _productService.DeleteProductById(id);

            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        //GET list of all products
        [HttpGet("Reviews/GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetReviewDto>>>> GetReviews() //returns a list of products
        {
            var response = await _productService.GetAllReviews();
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}