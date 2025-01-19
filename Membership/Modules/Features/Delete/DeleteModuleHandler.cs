using Membership.Modules.Contracts;
using Membership.Modules.Exceptions;

namespace Membership.Modules.Features.Delete;
public sealed record DeleteModuleCommand(Guid Id) : ICommand;

public class DeleteModuleCommandValidator : AbstractValidator<DeleteModuleCommand>
{
    public DeleteModuleCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id is required");
    }
}

internal sealed class DeleteModuleHandler(
    MembershipDbContext dbContext, 
    IModuleQueryRepository moduleQueryRepository) : ICommandHandler<DeleteModuleCommand>
{
    public async Task<Unit> Handle(DeleteModuleCommand request, CancellationToken cancellationToken)
    {
        ModuleModel? moduleDeleted = await moduleQueryRepository.GetByIdAsync(request.Id);

        if (moduleDeleted is null) throw new ModuleNotFoundException(request.Id);
        
        moduleDeleted.Delete();
            
        dbContext.Modules.Update(moduleDeleted);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}