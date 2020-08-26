using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthDemo.Data.Repositories.Repository;
using AuthDemo.Service.DTO;
using AuthDemo.Service.ProductService;
using AuthDemo.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthDemo.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ProductDTO> productDTO = productService.GetAll();
            List<ProductViewModel> productViewModel = MapProductDTOToViewModel(productDTO);

            return View(productViewModel);
        }

        private List<ProductViewModel> MapProductDTOToViewModel(List<ProductDTO> productDTO)
        {
            List<ProductViewModel> productViewModel = new List<ProductViewModel>();
            productDTO.ForEach(product =>
            {
                productViewModel.Add(new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    SalePrice = product.SalePrice
                });
            });
            return productViewModel;
        }
    }
}
