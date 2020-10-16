using PazzoApi.Service.Interface;
using PazzoApo.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PazzoApi.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ProductsBM>> GetAll()
        {
            return await _productsService.GetAllBMAsync();
        }
    }
}
