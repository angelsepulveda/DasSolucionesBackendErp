﻿using Membership.Modules.Contracts;

namespace Membership.Modules.Repositories;

internal sealed class ModuleQueryEfCoreRepository(MembershipDbContext dbContext) : IModuleQueryRepository
{
    public async Task<ModuleModel?> GetByIdAsync(Guid id) =>
        await dbContext.Modules.Where(x => x.Id == id).FirstOrDefaultAsync();
}