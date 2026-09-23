namespace ServerApiTemplate.Domain.Constants;

/// <summary>
/// Mã Activity (chức năng) cho phân quyền 6 bảng. Seeder đồng bộ danh sách <see cref="All"/> vào Sys_Activity
/// mỗi lần khởi động. Thêm chức năng mới = thêm hằng số + một dòng trong <see cref="All"/> (RULES.md §4).
/// </summary>
public static class ConstActivity
{
    public const string ApplicationName = "ServerApiTemplate";

    // --- Hệ thống (có sẵn trong template) ---
    public const string User = "USER";
    public const string Role = "ROLE";
    public const string ApiLog = "API_LOG";

    // --- Nghiệp vụ: thêm tại đây, ví dụ ---
    // public const string Product = "PRODUCT";

    public sealed record Definition(string Code, string Name, string Description);

    public static readonly IReadOnlyList<Definition> All =
    [
        new(User, "Người dùng", "R: xem user · U: khóa/mở, gán role, cấp quyền riêng"),
        new(Role, "Vai trò", "C: tạo · R: xem · U: sửa quyền role · D: xóa role"),
        new(ApiLog, "Log API", "R: xem log request/response API để debug")
        // new(Product, "Sản phẩm", "C: thêm · R: xem · U: sửa · D: xóa"),
    ];
}
