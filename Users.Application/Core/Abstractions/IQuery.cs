using MediatR;
using Users.Domain.Result;
namespace Users.Application.Core.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;