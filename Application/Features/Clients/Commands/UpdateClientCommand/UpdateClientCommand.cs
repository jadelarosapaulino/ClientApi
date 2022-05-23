using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using Domain.Enum;
using MediatR;

namespace Application.Features.Clients.Commands.UpdateClientCommand;

public class UpdateClientCommand : IRequest<Response<Guid>>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime BirtDate { get; set; }
    public char Gender { get; set; }
}

public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Response<Guid>>
{
    private readonly IRepositoryAsync<Client> _repositoryAsync;

    public UpdateClientCommandHandler(IRepositoryAsync<Client> repositoryAsync)
    {
        _repositoryAsync = repositoryAsync;
    }

    public async Task<Response<Guid>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _repositoryAsync.GetByIdAsync(request.Id);

        if (client == null)
        {
            throw new KeyNotFoundException($"Client with id: {request.Id} not found");
        } 
        else
        {
            client.Name = request.Name;
            client.LastName = request.LastName;
            client.Email = request.Email;
            client.BirtDate = request.BirtDate;
            client.Gender = request.Gender;

            await _repositoryAsync.UpdateAsync(client);

            return new Response<Guid>(client.Id);
        }

    }
}
