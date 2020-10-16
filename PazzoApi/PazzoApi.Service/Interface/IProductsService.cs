using PazzoApi.DB;
using PazzoApo.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazzoApi.Service.Interface
{
    public interface IProductsService : IBaseService<Products>
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="bm"></param>
        /// <returns></returns>
        Task<bool> Add(ProductsBM bm);

        /// <summary>
        /// 修改資料
        /// </summary>
        /// <param name="bm"></param>
        /// <returns></returns>
        Task<bool> Edit(ProductsBM bm);

        /// <summary>
        /// 刪除多筆資料
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool DeleteRange(int[] ids);

        /// <summary>
        /// 依ID取得資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductsBM GetByID(int id);

        Task<List<ProductsBM>> GetAllBMAsync();
    }
}
