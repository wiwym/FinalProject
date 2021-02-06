﻿using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
   public class ProductManager:IProductService
   {
       private IProductDal _productDal;

       public ProductManager(IProductDal productDal)
       {
           _productDal = productDal;
       }

       public List<Product> GetAll()
       {
           return _productDal.GetAll();
       }

       public List<Product> GetAllByCategoryId(int id)
       {
           return _productDal.GetAll(p => p.CategoryId == id);
       }

       public List<Product> GetAllByUnitPrice(decimal min, decimal max)
       {
           return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
       }

       public List<ProductDetailDTO> GetProductDetails()
       {
           return _productDal.GetProductDetails();
       }
   }
}
