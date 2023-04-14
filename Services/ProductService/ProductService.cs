using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Products.Services.ProductService
{
    public class ProductService : IProductService
    {
        private static List<Product> products = new List<Product>
        {
            new Product{ Name="Iphone", Price = 120, Category=Category.Cellphone},
            new Product{ Id= 1, Name="Asus", Price = 350}
        };
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        //Constructor
        public ProductService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto newProduct)
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>(); //create a new service response with data field null as default.
            var product = _mapper.Map<Product>(newProduct);
            
            _context.Products.Add(product); // add new product to the DB
            await _context.SaveChangesAsync(); //Save changes in DB
            
            var dbProducts = await _context.Products.ToListAsync(); //Get updated list of products and map it to generate Service Response
            serviceResponse.Message="Your product was successfully Added";
            serviceResponse.Data = dbProducts.Select(c => _mapper.Map<GetProductDto>(c)).ToList(); // fill the Data key with the updated list of products 
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProductDto>>> DeleteProductById(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();

             try
            {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
            if (dbProduct is null)
            {
                throw new Exception($"Product with id {id} was not found");
            }
            
            _context.Products.Remove(dbProduct);
            await _context.SaveChangesAsync();

            var dbProducts = await _context.Products.ToListAsync(); 
            serviceResponse.Message=$"Your product with id {id} was successfully deleted";
            serviceResponse.Data = dbProducts.Select(c => _mapper.Map<GetProductDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProductDto>>> GetAllProducts()
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();
            var dbProducts = await _context.Products.ToListAsync();
            serviceResponse.Data = dbProducts.Select(c => _mapper.Map<GetProductDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDto>> GetProductById(int id)
        {
            var serviceResponse = new ServiceResponse<GetProductDto>(); //generate an empty json with the default service response
            try
            {var dbProduct = await _context.Products.FirstOrDefaultAsync(c => c.Id == id); //bring the products that matches with the id from the parameter id in the URL
            
            serviceResponse.Data = _mapper.Map<GetProductDto>(dbProduct); //Fil the Data value of the service response with the product 
            serviceResponse.Message = $"Product with id {id} found";
            
            if (dbProduct is null) //if product is null, throw new exeption error
            {
                throw new Exception($"Product with id {id} was not found");  
            }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false; //modify success key and Message key with error message.
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetProductDto>> UpdateProduct(UpdateProductDto updatedProduct)
        {
            var serviceResponse = new ServiceResponse<GetProductDto>();
            try
            {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(c => c.Id == updatedProduct.Id);
            if (dbProduct is null)
            {
                throw new Exception($"Product with id {updatedProduct.Id} was not found");
            }
            dbProduct.Name = updatedProduct.Name;
            dbProduct.Description = updatedProduct.Description;
            dbProduct.Price = updatedProduct.Price;
            dbProduct.Image = updatedProduct.Image;
            dbProduct.Category = updatedProduct.Category;

            serviceResponse.Data = _mapper.Map<GetProductDto>(dbProduct);
            serviceResponse.Message = $"Your product with id {updatedProduct.Id} was successfully updated";
            
            await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

        }
    }
}