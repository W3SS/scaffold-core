using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using ScaffoldCore.Infrastructure.Interfaces;

namespace ScaffoldCore.Infrastructure.Queues
{
	public class RabbitManager : IRabbitManager
	{
		private ConnectionFactory Factory;

		public RabbitManager(ConnectionFactory connectionFactory)
		{
			Factory = connectionFactory;
		}

		public void Publish<T>(string queueName, T model, 
			string exchange = "", 
			bool durable= false, 
			bool exclusive = false, 
			bool autoDelete = false, 
			IDictionary<string, object> arguments = null)
				where T : class
		{
			using (var connection = Factory.CreateConnection())
			{
				using (var channel = connection.CreateModel())
				{
					channel.QueueDeclare(queue: queueName,
						durable: durable,
						exclusive: exclusive,
						autoDelete: autoDelete,
						arguments: arguments);

					var json = JsonConvert.SerializeObject(model);
					var body = Encoding.UTF8.GetBytes(json);

					channel.BasicPublish(exchange: exchange,
						routingKey: queueName,
						basicProperties: null,
						body: body);
				}
			}
		}

		public void Subscribe<T>(string queueName, EventHandler<BasicDeliverEventArgs> eventHandler,
			bool durable = false,
			bool exclusive = false,
			bool autoDelete = false,
			bool autoAck = true,
			IDictionary<string, object> arguments = null) 
				where T : class
		{
			using (var connection = Factory.CreateConnection())
			{
				using (var channel = connection.CreateModel())
				{
					channel.QueueDeclare(queue: queueName,
						durable: durable,
						exclusive: exclusive,
						autoDelete: autoDelete,
						arguments: arguments);

					var consumer = new EventingBasicConsumer(channel);
					consumer.Received += eventHandler;

					channel.BasicConsume(queue: queueName,
						autoAck: autoAck,
						consumer: consumer);
				}
			}
		}
	}
}
