using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clients.Queries;

public class GetClientListCommand : IRequest<Response<IList<Client>>>
{
}
public class GetClientListCommandHandler : IRequestHandler<GetClientListCommand, Response<IList<Client>>>
{
    private readonly IRepositoryAsync<Client> _repositoryAsync;
    private readonly IRepositoryAsync<Contact> _repositoryContact;

    public GetClientListCommandHandler(IRepositoryAsync<Client> repositoryAsync, IRepositoryAsync<Contact> repositoryContact)
    {
        _repositoryAsync = repositoryAsync;
        _repositoryContact = repositoryContact;
    }

    public async Task<Response<IList<Client>>> Handle(GetClientListCommand request, CancellationToken cancellationToken)
    {
        var result = await _repositoryAsync.ListAsync();

        foreach (var item in result)
        {

            var contacts = from c in _repositoryContact.ListAsync().Result
                           where c.ClientId == item.Id
                           where c.ClientId == item.Id
                                 select c;
            
            item.Contact = contacts.ToList();
        }
        return new Response<IList<Client>>(result);
    }
}