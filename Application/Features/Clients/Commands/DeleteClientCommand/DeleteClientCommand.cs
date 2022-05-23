using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clients.Commands.DeleteClientCommand;

public class DeleteClientCommand : IRequest<Response<Guid>>
{
    public Guid Id { get; set; }
}

public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Response<Guid>>
{
    private readonly IRepositoryAsync<Client> _repositoryAsync;

    public DeleteClientCommandHandler(IRepositoryAsync<Client> repositoryAsync)
    {
        _repositoryAsync = repositoryAsync;
    }
    public async Task<Response<Guid>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _repositoryAsync.GetByIdAsync(request.Id);

        if (client == null)
        {
            throw new KeyNotFoundException($"Client with id: {request.Id} not found");
        }
        else
        {
            await _repositoryAsync.DeleteAsync(client);

            return new Response<Guid>(client.Id);
        }
    }
}
