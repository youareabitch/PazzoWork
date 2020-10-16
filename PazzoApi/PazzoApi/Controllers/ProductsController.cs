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

        /// <summary>
        /// 取得單筆資料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ProductsBM GetById(int id)
        {
            return _productsService.GetByID(id);
        }

        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="bm"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> Add(ProductsBM bm)
        {
            return await _productsService.Add(bm);
        }

        /// <summary>
        /// 修改資料
        /// </summary>
        /// <param name="bm"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<bool> Edit(ProductsBM bm)
        {
            var editModel = _productsService.GetByID(bm.ProductID);

            editModel.ProductName = bm.ProductName;
            editModel.QuantityPerUnit = bm.QuantityPerUnit;
            editModel.UnitPrice = bm.UnitPrice;
            editModel.UnitsInStock = bm.UnitsInStock;
            editModel.UnitsOnOrder = bm.UnitsOnOrder;
            editModel.ReorderLevel = bm.ReorderLevel;
            editModel.Discontinued = bm.Discontinued;

            return await _productsService.Edit(editModel);
        }
    }
}
