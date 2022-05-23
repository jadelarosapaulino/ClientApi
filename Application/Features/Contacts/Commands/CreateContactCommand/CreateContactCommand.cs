using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Contacts.Commands.CreateContactCommand;

public class CreateContactCommand : IRequest<Response<Guid>>
{
    public string Description { get; set; }
    public Guid ClientId { get; set; }
}
public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Response<Guid>>
{
    private readonly IRepositoryAsync<Contact> _repositoryAsync;
    private readonly IMapper _mapper;

    public CreateContactCommandHandler(IRepositoryAsync<Contact> repositoryAsync, IMapper mapper)
    {
        _repositoryAsync = repositoryAsync;
        _mapper = mapper;
    }

    public async Task<Response<Guid>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = _mapper.Map<Contact>(request);
        var result = await _repositoryAsync.AddAsync(contact);
        return new Response<Guid>(result.Id);
    }
}    
