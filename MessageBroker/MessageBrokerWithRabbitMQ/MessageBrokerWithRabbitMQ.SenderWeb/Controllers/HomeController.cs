using MessageBrokerWithRabbitMQ.SenderWeb.Models;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Diagnostics;
using System.Text;

namespace MessageBrokerWithRabbitMQ.SenderWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel indexViewModel)
        {
            ConnectionFactory connectionFactory = new()
            {
                Uri = new Uri(_configuration.GetConnectionString("RabbitMQ")),
                ClientProvidedName = "RabbitMQ Sender"
            };

            IConnection connection = connectionFactory.CreateConnection();

            IModel model = connection.CreateModel();

            string exchangeName = "RabbitMQExchange";
            string routingKey = "rabbitmq-routing-key";
            string queueName = "RabbitMQQueue";

            model.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            model.QueueDeclare(queueName, false, false, false, null);
            model.QueueBind(queueName, exchangeName, routingKey, null);

            for (int i = 1; i <= indexViewModel.TotalMessage; i++)
            {
                byte[] messageBodyBytes = Encoding.UTF8.GetBytes($"Message request {i}");
                model.BasicPublish(exchangeName, routingKey, null, messageBodyBytes);
                Thread.Sleep(1000);
            }

            model.Close();
            connection.Close();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
