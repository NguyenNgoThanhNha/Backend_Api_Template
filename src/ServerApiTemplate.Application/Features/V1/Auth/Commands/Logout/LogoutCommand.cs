using ServerApiTemplate.Application.Common.Security;
using ServerApiTemplate.Domain.Entities.Sys;

namespace ServerApiTemplate.Application.Features.V1.Auth.Commands.Logout;

public sealed record LogoutCommand(string RefreshToken) : IRequest;

public sealed class LogoutCommandHandler(IUnitOfWork<ServerApiTemplateDbContext> unitOfWork, TimeProvider clock)
    : IRequestHandler<LogoutCommand>
{
    public async Task Handle(LogoutCommand request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.RefreshToken)) return;

        var hash = TokenHasher.Hash(request.RefreshToken);
        var stored = await unitOfWork.Repository<SysRefreshToken>().FirstOrDefaultAsync(t => t.TokenHash == hash, ct);
        if (stored is null) return;

        stored.Revoke(clock.GetUtcNow().UtcDateTime);
        await unitOfWork.SaveChangesAsync(ct);
    }
}
