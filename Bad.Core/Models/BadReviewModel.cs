namespace Bad.Core.Models
{
    public class BadReviewModel : BaseEntityModel<long>
    {
        public decimal Rating { get; set; }
        public string Message { get; set; }
    }
}
