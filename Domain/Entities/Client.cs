using Domain.Common;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Client : AuditableBaseEntity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public virtual ICollection<Contact> Contact { get; set; }
    public DateTime BirtDate { get; set; }
    public char Gender { get; set; }
}
