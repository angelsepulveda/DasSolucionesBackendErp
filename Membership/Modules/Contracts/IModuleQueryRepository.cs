namespace Membership.Modules.Contracts;

public interface IModuleQueryRepository
{
    Task<ModuleModel?> GetByIdAsync(Guid id);
}