using MediatR;

namespace CqrsDemo.Infrastructure
{
    public class RetryPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private const int MAX_RETRIES = 2;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            for (int i = 0; i < MAX_RETRIES; i++)
            {
                try
                {
                    return await next();
                }
                catch (RetryableException)
                {
                    //eat it
                }
            }
            return await next();
        }
    }
}
