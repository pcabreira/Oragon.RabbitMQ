using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Oragon.RabbitMQ.Serialization;

/// <summary>
/// Define a implementation of a serializer for AMQP
/// </summary>
public interface IAMQPSerializer
{
    /// <summary>
    /// Desserialize a message from a BasicDeliverEventArgs
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    /// <param name="basicDeliver"></param>
    /// <returns></returns>
    TMessage Deserialize<TMessage>(BasicDeliverEventArgs basicDeliver);


    /// <summary>
    /// Desserialize a message from a BasicDeliverEventArgs
    /// </summary>
    /// <param name="eventArgs"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    object Deserialize(BasicDeliverEventArgs eventArgs, Type type);


    /// <summary>
    /// Serialize a message to a byte array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="basicProperties"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    byte[] Serialize<T>(BasicProperties basicProperties, T message);

    /// <summary>
    /// Serialize a message to a byte array
    /// </summary>
    /// <param name="basicProperties"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    byte[] Serialize(BasicProperties basicProperties, object message);
}
