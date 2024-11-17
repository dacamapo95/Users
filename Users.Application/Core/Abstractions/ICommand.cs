using MediatR;
using Users.Domain.Result;

namespace Users.Application.Core.Abstractions;

public interface ICommand : IRequest<Result>;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>;
