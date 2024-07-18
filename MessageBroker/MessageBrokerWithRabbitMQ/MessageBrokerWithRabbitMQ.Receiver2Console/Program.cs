using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

ConnectionFactory connectionFactory = new()
{
    Uri = new Uri("amqp://guest:guest@localhost:5672"),
    ClientProvidedName = "RabbitMQ Receiver 2"
};

IConnection connection = connectionFactory.CreateConnection();

IModel model = connection.CreateModel();

string exchangeName = "RabbitMQExchange";
string routingKey = "rabbitmq-routing-key";
string queueName = "RabbitMQQueue";

model.ExchangeDeclare(exchangeName, ExchangeType.Direct);
model.QueueDeclare(queueName, false, false, false, null);
model.QueueBind(queueName, exchangeName, routingKey, null);
model.BasicQos(0, 1, false);

EventingBasicConsumer eventingBasicConsumer = new(model);

eventingBasicConsumer.Received += (sender, args) =>
{
    Task.Delay(TimeSpan.FromSeconds(3)).Wait();

    var body = args.Body.ToArray();

    string message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"Message Received: {message}");

    model.BasicAck(args.DeliveryTag, false);
};

string consumerTag = model.BasicConsume(queueName, false, eventingBasicConsumer);

Console.ReadLine();

model.BasicCancel(consumerTag);
model.Close();

connection.Close();