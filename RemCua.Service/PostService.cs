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
    public interface IPostService
    {
        Post Add(Post post);

        void Update(Post post);

        Post Delete(int id);

        IEnumerable<Post> GetAll();

        IEnumerable<Post> GetNewPost(int top);

        Post GetById(int id);

        bool ChangeStatus(int id);

        IEnumerable<Post> GetListPosyPaging(int page, int pageSize, out int totalRow);
        IEnumerable<Post> GetReatedPost(int id, int top);

        void SaveChanges();
    }
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }
        public Post Add(Post post)
        {
            return _postRepository.Add(post);
        }

        public Post Delete(int id)
        {
            return _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public IEnumerable<Post> GetListPosyPaging(int page, int pageSize, out int totalRow)
        {
            var query = _postRepository.GetAll();
            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Post> GetNewPost(int top)
        {
            return _postRepository.GetMulti(x => x.Status).OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public IEnumerable<Post> GetReatedPost(int id, int top)
        {
            var post = _postRepository.GetSingleById(id);
            return _postRepository.GetMulti(x => x.Status == true && x.ID != id && x.CategoryID == post.CategoryID).OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool ChangeStatus(int id)
        {

            var post = _postRepository.GetSingleById(id);
            post.Status = !post.Status;
            return post.Status;
        }
        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}
