using MediatR;

namespace CqrsDemo.Infrastructure
{
    public class AuthBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ContextualRequest<TResponse>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            request.Metadata["CurrentUser"] = _httpContextAccessor.HttpContext?.User;
            request.Metadata["Now"] = DateTime.UtcNow;
            return next();
        }
    }
}
