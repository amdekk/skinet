using Core.Entities;
using System;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class PoductWithTypesAndBrandsSpecification : BaseSpcification<Product>
    {
        public PoductWithTypesAndBrandsSpecification()
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }

        public PoductWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}