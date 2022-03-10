using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarNoteWebAPICore.DataAccess;
using StarNoteWebAPICore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace StarNoteWebAPICore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly StarNoteEntity _context;
        UnitOfWork unitOfWork;

        public ProductController(ILogger<ProductController> logger, StarNoteEntity context)
        {
            _logger = logger;
            _context = context;
            unitOfWork = new UnitOfWork(context);
        }
        [HttpGet]
        [Route("GetAll")]
        public List<ProductModel> Getlist()
        {
            return unitOfWork.ProductRepository.GetAll();
        }
        [Route("Add")]
        [HttpPost]
        public bool Add(ProductModel obj)
        {
            bool IsAdded = false;
            unitOfWork.ProductRepository.Add(obj);
            if (unitOfWork.Complate() > 0)
                IsAdded = true;
            return IsAdded;
        }
        [Route("Update")]
        [HttpPost]
        public bool Update(ProductModel obj)
        {
            bool Isupdated = false;
            unitOfWork.ProductRepository.update(unitOfWork.ProductRepository.Getbyid(obj.Id), obj);
            if (unitOfWork.Complate() > 0)
                Isupdated = true;
            return Isupdated;
        }
        [Route("Delete")]
        [HttpPost]
        public bool Delete(ProductModel obj)
        {
            bool IsDeleted = false;
            unitOfWork.ProductRepository.Remove(obj.Id);
            if (unitOfWork.Complate() > 0)
                IsDeleted = true;
            return IsDeleted;
        }
    }
}
