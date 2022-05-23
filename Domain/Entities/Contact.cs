using Domain.Common;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Contact : AuditableBaseEntity
{
    public string Description { get; set; }
    //public ContactType ContactType { get; set; }
    public Guid ClientId { get; set; }
    public Client Client { get; set; }
}
