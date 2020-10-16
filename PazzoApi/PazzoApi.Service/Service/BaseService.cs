using PazzoApi.Service.Interface;
using PazzoApi.Service.Repository;
using PazzoApi.Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PazzoApi.Service.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        protected IGenericRepository<TEntity> _repository { get; set; }

        public BaseService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> repository)
        {
            this._unitOfWork = unitOfWork;
            this._repository = repository;
        }

        public virtual async Task<bool> Create(TEntity entity)
        {
            var result = await _repository.Create(entity);
            return result;
        }

        public virtual async Task<bool> Update(TEntity entity, params object[] keyValues)
        {
            bool result = false;
            if (null != entity)
            {
                result = await _repository.Update(entity, keyValues);
            }
            return result;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            bool result = false;
            var entity = _repository.GetById(id);
            await _repository.Delete(entity);
            _repository.UnitOfWork.SaveChange();
            result = true;
            return result;
        }

        public virtual bool DeleteGroup(IList<TEntity> entities)
        {
            bool result = false;
            _repository.DeleteRange(entities);
            result = true;
            return result;
        }

        public virtual Task<IQueryable<TEntity>> GetAll()
        {
            var result = _repository.GetAll();
            return result;
        }

        public virtual TEntity GetById(int id)
        {
            var result = _repository.GetById(id);
            return result;
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.FindBy(predicate);
        }
    }
}
