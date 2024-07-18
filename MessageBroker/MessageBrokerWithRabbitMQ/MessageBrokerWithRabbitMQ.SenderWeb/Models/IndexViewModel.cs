using System.ComponentModel.DataAnnotations;

namespace MessageBrokerWithRabbitMQ.SenderWeb.Models
{
    public class IndexViewModel
    {
        [Required(ErrorMessage = "Total message is required !")]
        public int TotalMessage { get; set; }
    }
}
