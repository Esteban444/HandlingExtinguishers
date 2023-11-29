using HandlingExtinguishers.Dto.Models;

namespace HandlingEstinguisherS.Dto.Models
{
    public class DetailServiceDetailClient
    {
        public Guid Id { get; set; }
        public Guid? IdDetailService { get; set; }
        public Guid? IdDetailExtinguisherClient { get; set; }

        public DetailExtinguisherClient? DetaileExtinguisherClient { get; set; }
        public DetailService? DetailService { get; set; }
    }
}
