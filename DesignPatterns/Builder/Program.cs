﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            var builder = new OldCustomerProductBuilder();
            productDirector.GenerateProduct(builder);

            var model = builder.GetModel();

            Console.WriteLine(model.Id);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.DiscountApplied);
            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.UnitPrice);

            Console.ReadLine();
        }
    }

    class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }

    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel viewModel = new ProductViewModel();
        public override void ApplyDiscount()
        {
            viewModel.DiscountedPrice = viewModel.UnitPrice * (decimal)0.90;
            viewModel.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return viewModel;
        }

        public override void GetProductData()
        {
            viewModel.Id = 1;
            viewModel.CategoryName = "Beverages";
            viewModel.ProductName = "Chai";
            viewModel.UnitPrice = 20;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel viewModel = new ProductViewModel();
        public override void ApplyDiscount()
        {
            viewModel.DiscountedPrice = viewModel.UnitPrice;
            viewModel.DiscountApplied = false;
        }

        public override ProductViewModel GetModel()
        {
            return viewModel;
        }

        public override void GetProductData()
        {
            viewModel.Id = 1;
            viewModel.CategoryName = "Beverages";
            viewModel.ProductName = "Chai";
            viewModel.UnitPrice = 20;
        }
    }

    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();

        }
    }

}
