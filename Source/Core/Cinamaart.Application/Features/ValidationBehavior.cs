﻿using FluentValidation;
using MediatR;

namespace Cinamaart.Application.Features
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
           where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        Task<TResponse> IPipelineBehavior<TRequest, TResponse>.Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var validationContext = new ValidationContext<TRequest>(request);
            cancellationToken.ThrowIfCancellationRequested();

            var validationFailures = _validators.Select(x => x.Validate(validationContext))
                                              .SelectMany(x => x.Errors)
                                              .Where(x => x != null)
                                              .ToList();

            if (validationFailures.Any())
            {
                throw new ValidationException(validationFailures);
            }

            return next();
        }
    }
}
