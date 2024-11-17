using MediatR;
using Users.Domain.Result;

namespace Users.Application.Core.Abstractions;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;