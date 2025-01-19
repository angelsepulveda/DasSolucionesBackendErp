using Shared.Exceptions;

namespace Membership.Modules.Exceptions;

public class ModuleNotFoundException : NotFoundException
{
    public ModuleNotFoundException(Guid id) 
        : base("Module", id)
    {
    }
}