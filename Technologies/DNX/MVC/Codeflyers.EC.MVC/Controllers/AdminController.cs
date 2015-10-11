using System.Collections.Generic;
using System.IO;
using System.Linq;
using Codeflyers.EC.Domain.Abstract;
using Codeflyers.EC.Domain.Entities;
using Codeflyers.EC.MVC.Infrastructure;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http;
using Microsoft.Net.Http.Headers;

namespace Codeflyers.EC.MVC.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository _productRepository;

        public AdminController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public ViewResult Index()
        {
            return View(_productRepository.GetAll());
        }

        public ViewResult Edit(int productId)
        {
            var product = _productRepository.GetAll().FirstOrDefault(p => p.ProductId == productId);
            return View(product);
        }

        //[HttpPost]
        //public ActionResult Edit(Product product, HttpPostedFileBase image)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (image != null)
        //        {
        //            product.ImageMimeType = image.ContentType;
        //            product.ImageData = new byte[image.ContentLength];
        //            image.InputStream.Read(product.ImageData, 0, image.ContentLength);
        //        }
        //        _productRepository.AddOrUpdate(product);
        //        TempData["message"] = string.Format("{0} has been saved successfully", product.Title);

        //        return RedirectToAction("Index");
        //    }
        //    return View(product);
        //}

        [HttpPost]
        public ActionResult Edit(Product product, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    FileDetails fileDetails;
                    using (var reader = new StreamReader(image.OpenReadStream()))
                    {
                        var fileContent = reader.ReadToEnd();
                        var parsedContentDisposition = ContentDispositionHeaderValue.Parse(image.ContentDisposition);
                        fileDetails = new FileDetails
                        {
                            Filename = parsedContentDisposition.FileName,
                            Content = fileContent,
                            ContentType=image.ContentType
                        };
                    }
                    //product.ImageMimeType = image.ContentType;
                    product.ImageData = fileDetails.Content;
                }
                _productRepository.AddOrUpdate(product);
                TempData["message"] = string.Format("{0} has been saved successfully", product.Title);

                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int bookId)
        {
            Product product = _productRepository.Remove(bookId);
            if (product != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", @product.Title);
            }
            return RedirectToAction("Index");
        }


    }
}
