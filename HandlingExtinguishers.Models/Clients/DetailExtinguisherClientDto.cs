namespace HandlingExtinguisher.Dto.Clients
{
    public class DetailExtinguisherClientDto : BaseDetailExtinguisherClient
    {
        public Guid Id { get; set; }

        public ClientDto? Client { get; set; }
    }
}
