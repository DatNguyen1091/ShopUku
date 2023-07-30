using ShopUku_DAL.Model;
using ShopUku_DAL.Repository;

namespace ShopUku_BAL.Services
{
    public class FeedbackService
    {
        private FeedbackRepository _feedbackRepository;

        public FeedbackService(FeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public List<Feedback> GetAllFeedback(int? page)
        {
            return _feedbackRepository.GetAll(page);
        }

        public Feedback GetFeedbackById(int id)
        {
            return _feedbackRepository.GetById(id);
        }

        public Feedback CreateFeedback(Feedback model)
        {
            return _feedbackRepository.Create(model);
        }

        public string RemoveFeedback(int id)
        {
            var result = _feedbackRepository.Delete(id);
            return result;
        }
    }
}
