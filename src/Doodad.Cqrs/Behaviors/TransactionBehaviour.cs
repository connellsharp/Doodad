using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Doodad.Cqrs.Behaviors
{
    public class TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private IUnitOfWork _unitOfWork;

        public TransactionBehaviour(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();

            await _unitOfWork.CommitAsync(cancellationToken);

            return response;
        }
    }
}
