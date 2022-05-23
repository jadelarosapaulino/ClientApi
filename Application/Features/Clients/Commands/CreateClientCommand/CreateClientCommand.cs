using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clients.Commands.CreateClientCommand;

public class CreateClientCommand : IRequest<Response<Guid>>
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime BirtDate { get; set; }
    public char Gender { get; set; }
}
public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Response<Guid>>
{
    private readonly IRepositoryAsync<Client> _repositoryAsync;
    private readonly IMapper _mapper;
    public CreateClientCommandHandler(IRepositoryAsync<Client> repositoryAsync, IMapper mapper)
    {
        _repositoryAsync = repositoryAsync;
        _mapper = mapper;
    }
    public async Task<Response<Guid>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var client = _mapper.Map<Client>(request);
        var result = await _repositoryAsync.AddAsync(client);
        return new Response<Guid>(result.Id);
    }
}
