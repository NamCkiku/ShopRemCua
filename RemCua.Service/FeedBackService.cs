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
    public interface IFeedbackService
    {
        Feedback Add(Feedback feedBack);

        void Update(Feedback feedBack);

        Feedback Delete(int id);

        IEnumerable<Feedback> GetAll();

        Feedback GetById(int id);

        void SaveChanges();
    }
    public class FeedbackService : IFeedbackService
    {
        private IFeedbackRepository _feedbackRepository;
        private IUnitOfWork _unitOfWork;

        public FeedbackService(IFeedbackRepository feedbackRepository, IUnitOfWork unitOfWork)
        {
            this._feedbackRepository = feedbackRepository;
            this._unitOfWork = unitOfWork;
        }

        public Feedback Add(Feedback feedBack)
        {
            return _feedbackRepository.Add(feedBack);
        }

        public Feedback Delete(int id)
        {
            return _feedbackRepository.Delete(id);
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _feedbackRepository.GetAll();
        }

        public Feedback GetById(int id)
        {
            return _feedbackRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Feedback feedBack)
        {
            _feedbackRepository.Update(feedBack);
        }
    }
}
