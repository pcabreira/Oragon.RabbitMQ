// Licensed to LuizCarlosFaria, gaGO.io, Mensageria .NET, Cloud Native .NET and ACADEMIA.DEV under one or more agreements.
// The ACADEMIA.DEV licenses this file to you under the MIT license.

using Dawn;

namespace Oragon.RabbitMQ.Consumer.Dispatch;

/// <summary>
/// Represents an attribute that can be used to bind an argument to an AMQP message.
/// </summary>
public class MessageObjectArgumentBinder : IAmqpArgumentBinder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MessageObjectArgumentBinder"/> class with the specified type.
    /// </summary>
    /// <param name="type"></param>
    public MessageObjectArgumentBinder(Type type)
    {
        this.Type = type;
    }

    /// <summary>
    /// Gets the type of the argument.
    /// </summary>
    public Type Type { get; }


    /// <summary>
    /// Gets the value of the argument.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public object GetValue(IAmqpContext context)
    {
        _ = Guard.Argument(context).NotNull();

        return context.MessageObject;
    }
}
