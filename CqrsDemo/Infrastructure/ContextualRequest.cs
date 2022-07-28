using MediatR;
using System.Text.Json.Serialization;

namespace CqrsDemo.Infrastructure
{
    public abstract class ContextualRequest<TResponse> : IRequest<TResponse>
    {
        [JsonIgnore]
        public IDictionary<string, object?> Metadata { get; } = new Dictionary<string, object?>();
    }
}
