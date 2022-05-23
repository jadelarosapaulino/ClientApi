using Application.Features.Clients.Commands.CreateClientCommand;
using Application.Features.Contacts.Commands.CreateContactCommand;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        #region Commands
        CreateMap<CreateClientCommand, Client>();
        CreateMap<CreateContactCommand, Contact>();
        #endregion
    }

}
