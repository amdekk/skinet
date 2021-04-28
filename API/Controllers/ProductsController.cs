using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _products;
        private readonly IGenericRepository<ProductBrand> _productrands;
        private readonly IGenericRepository<ProductType> _productTypes;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> products, IGenericRepository<ProductBrand> productrands,
                                    IGenericRepository<ProductType> productTypes, IMapper mapper)
        {
            _products = products;
            _productrands = productrands;
            _productTypes = productTypes;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecParams productParams)
        { 
            var spec = new PoductWithTypesAndBrandsSpecification(productParams);
            var products = await _products.ListAsync(spec);
            
            return Ok(_mapper
                     .Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var products = await _productTypes.ListAllAsync();
            return Ok(products);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var products = await _productrands.ListAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new PoductWithTypesAndBrandsSpecification(id);
            var product = await _products.GetEntityWithSpec(spec);

            return _mapper.Map<Product,ProductToReturnDto>(product);
        }
    }
}