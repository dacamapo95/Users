using Carter;
using Mapster;
using MediatR;
using Users.Domain.Result;
using Users.Application.Features.Users.Create;
using Users.Shared;
using Users.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Users.Application.Features.Users.GetById;
using Users.Application.Features.Users.Update;
using Users.Application.Features.Users.Delete;
using Users.Application.Features.Users.Get;
using Users.Application.Features.Users.AddAddress;
using Users.Application.Features.Users.RemoveAddress;

namespace Users.API.Endpoints;

public class Users : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/users")
            .WithTags(nameof(Users))
            .WithOpenApi();

        group.MapPost("/", CreateUser)
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status409Conflict)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
            .Produces<Guid>(StatusCodes.Status201Created);

        group.MapGet("/{userId}", GetUserById)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
            .Produces<UserDetailResponse>(StatusCodes.Status200OK);

        group.MapPut("/{userId}", UpdateUser)
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
            .Produces(StatusCodes.Status204NoContent);

        group.MapDelete("/{userId}", DeleteUser)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
            .Produces(StatusCodes.Status204NoContent);

        group.MapGet("/", GetUsers)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
            .Produces<UserResponse[]>(StatusCodes.Status200OK);

        group.MapPost("/{userId}/addresses", AddAddress)
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
            .Produces(StatusCodes.Status204NoContent);

        group.MapDelete("/{userId}/addresses/{addressId}", RemoveAddress)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
            .Produces(StatusCodes.Status204NoContent);

    }

    private async Task<IResult> CreateUser(ISender sender, [FromBody] CreateUserRequest request)
    {
        var result = await sender.Send(request.Adapt<CreateUserCommand>());
        return result.Match(Results.Ok, ResultExtension.ResultToResponse);
    }

    private async Task<IResult> GetUserById(ISender sender, [FromRoute] Guid userId)
    {
        var result = await sender.Send(new GetUserByIdQuery(userId));
        return result.Match(Results.Ok, ResultExtension.ResultToResponse);
    }

    private async Task<IResult> UpdateUser(ISender sender, [FromRoute] Guid userId, [FromBody] UpdateUserRequest request)
    {
        var command = request.Adapt<UpdateUserCommand>();
        var result = await sender.Send(command with { Id = userId });
        return result.Match(Results.NoContent, ResultExtension.ResultToResponse);
    }

    private async Task<IResult> DeleteUser(ISender sender, [FromRoute] Guid userId)
    {
        var result = await sender.Send(new DeleteUserCommand(userId));
        return result.Match(Results.NoContent, ResultExtension.ResultToResponse);
    }

    private async Task<IResult> GetUsers(ISender sender)
    {
        var result = await sender.Send(new GetUsersQuery());
        return result.Match(Results.Ok, ResultExtension.ResultToResponse);
    }

    private async Task<IResult> AddAddress(ISender sender, [FromRoute] Guid userId, [FromBody] AddressRequest request)
    {
        var command = request.Adapt<AddAddressCommand>();
        var result = await sender.Send(command with { UserId = userId });
        return result.Match(Results.NoContent, ResultExtension.ResultToResponse);
    }

    private async Task<IResult> RemoveAddress(ISender sender, [FromRoute] Guid userId, [FromRoute] Guid addressId)
    {
        var result = await sender.Send(new RemoveAddressCommand(userId, addressId));
        return result.Match(Results.NoContent, ResultExtension.ResultToResponse);
    }

}
