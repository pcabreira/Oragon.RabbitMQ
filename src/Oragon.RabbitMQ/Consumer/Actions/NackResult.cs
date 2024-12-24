using Dawn;

namespace Oragon.RabbitMQ.Consumer.Actions;

/// <summary>
/// Nack the message
/// </summary>
/// <remarks>
/// Creates a new instance of <see cref="NackResult"/>
/// </remarks>
/// <param name="requeue"></param>
public class NackResult(bool requeue) : IAMQPResult
{

    /// <summary>
    /// Indicates if the message should be requeued
    /// </summary>
    public bool Requeue { get; } = requeue;


    /// <summary>
    /// Perform ack on channel
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual async Task ExecuteAsync(IAmqpContext context)
    {
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        await context.Channel.BasicNackAsync(context.Request.DeliveryTag, false, this.Requeue).ConfigureAwait(false);
    }
}
