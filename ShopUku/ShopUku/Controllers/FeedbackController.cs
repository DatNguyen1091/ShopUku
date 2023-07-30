using Microsoft.AspNetCore.Mvc;
using ShopUku_BAL.Services;
using ShopUku_DAL.Model;

namespace ShopUku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackService _feedbackService;
        public FeedbackController(FeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public List<Feedback> GetBrands(int? page)
        {
            return _feedbackService.GetAllFeedback(page);
        }

        [HttpGet("{id}")]
        public Feedback GetBrandsId(int id)
        {
            return _feedbackService.GetFeedbackById(id);
        }

        [HttpPost]
        public Feedback PostBrands(Feedback model)
        {
            return _feedbackService.CreateFeedback(model);
        }

        [HttpDelete("{id}")]
        public string DeleteBrands(int id)
        {
            return _feedbackService.RemoveFeedback(id);
        }
    }
}
