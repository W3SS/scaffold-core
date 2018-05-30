using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScaffoldCore.Infrastructure.Interfaces
{
	public interface IRabbitManager
	{
		/// <summary>
		/// Publishes a model the specified queue.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="queueName">Name of the queue.</param>
		/// <param name="model">The model.</param>
		/// <param name="exchange">The exchange.</param>
		/// <param name="durable">if set to <c>true</c> [durable].</param>
		/// <param name="exclusive">if set to <c>true</c> [exclusive].</param>
		/// <param name="autoDelete">if set to <c>true</c> [automatic delete].</param>
		/// <param name="arguments">The arguments.</param>
		void Publish<T>(string queueName, T model,
			string exchange = "",
			bool durable = false,
			bool exclusive = false,
			bool autoDelete = false,
			IDictionary<string, object> arguments = null)
				where T : class;

		/// <summary>
		/// Subscribes the specified queue.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="queueName">Name of the queue.</param>
		/// <param name="eventHandler">The event handler.</param>
		/// <param name="durable">if set to <c>true</c> [durable].</param>
		/// <param name="exclusive">if set to <c>true</c> [exclusive].</param>
		/// <param name="autoDelete">if set to <c>true</c> [automatic delete].</param>
		/// <param name="autoAck">if set to <c>true</c> [automatic ack].</param>
		/// <param name="arguments">The arguments.</param>
		void Subscribe<T>(string queueName, EventHandler<BasicDeliverEventArgs> eventHandler,
			bool durable = false,
			bool exclusive = false,
			bool autoDelete = false,
			bool autoAck = true,
			IDictionary<string, object> arguments = null)
				where T : class;
	}
}
