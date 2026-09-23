using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ServerApiTemplate.Persistence;

/// <summary>
/// Cho lệnh `dotnet ef` tạo DbContext mà không khởi động Api (không chạy seed, background job...).
/// Connection string lấy từ biến môi trường HELPDESK_DESIGN_CONNECTION (chỉ cần khi `database update`).
/// </summary>
public sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ServerApiTemplateDbContext>
{
    public ServerApiTemplateDbContext CreateDbContext(string[] args)
    {
        var connection = Environment.GetEnvironmentVariable("HELPDESK_DESIGN_CONNECTION")
                         ?? "Server=.\\MSSQLSERVER01;Database=ServerApiTemplateDb;Trusted_Connection=True;TrustServerCertificate=True";
        var options = new DbContextOptionsBuilder<ServerApiTemplateDbContext>().UseSqlServer(connection).Options;
        return new ServerApiTemplateDbContext(options);
    }
}
