using RemCua.Entities.Models;
using RemCua.Repository.Infrastructure;
using RemCua.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCua.Service
{
    public interface IProductService
    {
        Product Add(Product product);

        void Update(Product product);

        Product Delete(int id);

        IEnumerable<Product> GetAll();

        Product GetById(int id);

        IEnumerable<Product> ListFeatureProduct(int top);
        IEnumerable<Product> ListNewProduct(int top);

        IEnumerable<Product> GetReatedProduct(int id, int top);

        IEnumerable<Product> GetListProductByCategoryIdPaging(int categoryId, int page, int pageSize, out int totalRow);

        IEnumerable<Product> Search(string keyword, int page, int pageSize, out int totalRow);

        bool ChangeStatus(int id);
        void SaveChanges();
    }
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
        }

        public Product Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public Product Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
        /// <summary>
        /// Sản Phẩm Nổi Bật,Hot
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public IEnumerable<Product> ListFeatureProduct(int top)
        {
            return _productRepository.GetMulti(x => x.Status == true && x.HotFlag == true).OrderByDescending(x => x.CreatedDate).Take(top);
        }
        /// <summary>
        /// Sản Phẩm Mới Nhất
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public IEnumerable<Product> ListNewProduct(int top)
        {
            return _productRepository.GetMulti(x => x.Status == true).OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public IEnumerable<Product> GetReatedProduct(int id, int top)
        {
            var product = _productRepository.GetSingleById(id);
            return _productRepository.GetMulti(x => x.Status == true && x.ID != id && x.CategoryID == product.CategoryID).OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public bool ChangeStatus(int id)
        {

            var product = _productRepository.GetSingleById(id);
            product.Status = !product.Status;
            return product.Status;
        }

        public IEnumerable<Product> GetListProductByCategoryIdPaging(int categoryId, int page, int pageSize, out int totalRow)
        {
            var query = _productRepository.GetMulti(x => x.Status == true && x.CategoryID == categoryId);
            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Product> Search(string keyword, int page, int pageSize, out int totalRow)
        {
            var query = _productRepository.GetMulti(x => x.Status && x.Name.Contains(keyword));

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
