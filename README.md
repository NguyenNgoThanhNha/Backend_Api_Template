# 🚀 ServerApiTemplate

ServerApiTemplate là một template dành cho các dự án ASP.NET Core API, giúp bạn khởi tạo nhanh chóng một API server với cấu trúc chuẩn.

## 📋 Mục lục

- [Yêu cầu hệ thống](#yêu-cầu-hệ-thống)
- [Cài đặt](#cài-đặt)
- [Cấu hình dự án](#cấu-hình-dự-án)
- [Chạy dự án](#chạy-dự-án)
- [Cấu trúc dự án](#cấu-trúc-dự-án)
- [Đóng góp](#đóng-góp)

## 🛠️ Yêu cầu hệ thống

- .NET Core 6.0 hoặc cao hơn
- Visual Studio 2022 hoặc Visual Studio Code
- [PowerToys](https://github.com/microsoft/PowerToys) (khuyến nghị cho việc đổi tên hàng loạt)

## 📥 Cài đặt

### Bước 1: Tải source code

Bạn có thể tải source code bằng một trong hai cách sau:

#### Cách 1: Clone từ GitHub
```bash
git clone https://github.com/your-username/ServerApiTemplate.git
cd ServerApiTemplate
```

#### Cách 2: Download ZIP
1. Truy cập [GitHub repository](https://github.com/your-username/ServerApiTemplate)
2. Bấm vào nút **Code** → **Download ZIP**
3. Giải nén file về máy

### Bước 2: Đổi tên dự án

> **Lưu ý:** Cần cài đặt [PowerToys](https://apps.microsoft.com/store/detail/microsoft-powertoys/XP89DCGQ3K6VLD) để sử dụng PowerRename

1. Chuột phải vào thư mục dự án đã tải về
2. Chọn **PowerRename**
3. Trong ô **"Search for"**: nhập `ServerApiTemplate`
4. Trong ô **"Replace with"**: nhập tên dự án mới (ví dụ: `MyCoolApi`)
5. Nhấn **Apply** để rename tất cả file, folder và class

### Bước 3: Cập nhật nội dung trong solution

1. Mở file `.sln` đã được rename trong Visual Studio (ví dụ: `MyCoolApi.sln`)
2. Nhấn `Ctrl + Shift + F` để mở Find and Replace
3. Điền thông tin:
   - **Find what**: `ServerApiTemplate`
   - **Replace with**: `MyCoolApi` (tên dự án của bạn)
   - **Look in**: `Entire Solution`
4. Nhấn **Replace All**

> ✅ Thao tác này sẽ tự động cập nhật namespace, config, class name và các tham chiếu khác trong source code.

## 🚀 Chạy dự án

### Build và khởi chạy

1. Build solution: `Ctrl + Shift + B`
2. Chạy dự án: Nhấn nút ▶️ hoặc `F5`
3. Mở trình duyệt và truy cập: `https://localhost:5001/swagger`

### Sử dụng Command Line

```bash
# Build dự án
dotnet build

# Chạy dự án
dotnet run

# Hoặc chạy với watch mode (tự động reload khi có thay đổi)
dotnet watch run
```

## 📁 Cấu trúc dự án

```
ServerApiTemplate/
├── .idea/                    # JetBrains IDE configuration
├── .vs/                      # Visual Studio configuration
├── CommonLibrary/            # Thư viện chung, utilities
├── DomainService/           # Business logic và domain services
├── Infrastructure/          # Data access, external services
├── Model/                   # Data models và entities
├── ServerApi/               # Main API project
├── .gitignore              # Git ignore file
├── ServerApi.sln           # Visual Studio Solution file
└── README.md               # Tài liệu dự án
```

## 🏗️ Kiến trúc dự án

Dự án được tổ chức theo mô hình **Clean Architecture** với các layer rõ ràng:

### 🔹 **ServerApi** 
- Main API project chứa Controllers, Middlewares
- Entry point của ứng dụng (Program.cs, Startup.cs)
- API endpoints và Swagger configuration

### 🔹 **Model** 
- Data Transfer Objects (DTOs)
- Request/Response models
- Validation attributes

### 🔹 **DomainService**
- Business logic và domain services
- Application services layer
- Domain entities và business rules

### 🔹 **Infrastructure**
- Data access layer (Repository pattern)
- Database context và configurations
- External service integrations
- Caching, logging implementations

### 🔹 **CommonLibrary**
- Shared utilities và helper methods
- Extension methods
- Common constants và enums
- Cross-cutting concerns

- ✅ Swagger/OpenAPI documentation
- ✅ Entity Framework Core integration
- ✅ Dependency Injection container
- ✅ Logging configuration
- ✅ CORS policy setup
- ✅ Health checks
- ✅ Exception handling middleware

## 🔧 Các tính năng có sẵn

Dự án đã được cấu hình sẵn các biện pháp bảo mật cơ bản:
- HTTPS redirect
- Security headers
- Input validation
- Rate limiting (nếu có)

## 📚 Tài liệu tham khảo

- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [Swagger/OpenAPI](https://swagger.io/docs/)

## 🤝 Đóng góp

Chúng tôi hoan nghênh mọi đóng góp! Vui lòng:

1. Fork repository này
2. Tạo feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Tạo Pull Request

## 📝 License

Dự án này được phân phối dưới giấy phép MIT. Xem file [LICENSE](LICENSE) để biết thêm chi tiết.

## 📞 Liên hệ

- **Email**: your-email@example.com
- **GitHub**: [@your-username](https://github.com/your-username)
- **LinkedIn**: [Your Name](https://linkedin.com/in/your-profile)

---

⭐ Nếu template này hữu ích cho bạn, hãy cho chúng tôi một star nhé!