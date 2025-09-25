using Common.Utils;
using Controllers;
using DomainService.Interfaces.Account;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.RequestModel.Common;
using Model.RequestModel.PermissionManagement;

namespace ServerApi.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IHttpContextAccessor httpContextAccessor, IAuthService _authService, IUserService _userService, 
                                IValidator<SysAccountRequest> _validator) : BaseController(httpContextAccessor)
    {

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<object> SignIn(LoginRequest req)
        {
            var userDevice = GetRequestDeviceInfo(Request);

            var res = await _authService.Login(req.UserName, req.Password, userDevice);
            return Ok(res);
        }

        [AllowAnonymous]
        [HttpPost("login-otp")]
        public async Task<object> LoginByOTP(LoginByOTPRequest req)
        {
            var userDevice = GetRequestDeviceInfo(Request);
            var deviceInfo = new DeviceInfoRequest
            {
                UDID = userDevice.DeviceUUID ?? "",
                DeviceName = userDevice.DeviceName,
                OSName = userDevice.DeviceOS,
                OSVersion = userDevice.DevicePlatform
            };
            var res = await _authService.LoginByOTP(req, deviceInfo, ipAddress);
            return Ok(res);
        }

        [AllowAnonymous]
        [HttpPost("refresh-access-token")]
        public async Task<object> RefreshAccessToken(RefreshTokenRequest req)
        {
            var userDevice = GetRequestDeviceInfo(Request);
            var deviceInfo = new DeviceInfoRequest
            {
                UDID = userDevice.DeviceUUID ?? "",
                DeviceName = userDevice.DeviceName,
                OSName = userDevice.DeviceOS,
                OSVersion = userDevice.DevicePlatform
            };
            var res = await _authService.GetNewTokenByRefreshToken(req, deviceInfo, ipAddress);
            return Ok(res);
        }

        // [AllowAnonymous]
        // [HttpGet("signin-google")]
        // public IActionResult SignInGoogle()
        // {
        //     var properties = new AuthenticationProperties
        //     {
        //         RedirectUri = Url.Action("GoogleResponse")
        //     };
        //     return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        // }
        //
        
        [AllowAnonymous]
        [HttpGet("login-google")]
        public async Task<IActionResult> GoogleResponseAsync()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
        
            var accessToken = result.Properties.GetTokenValue("access_token");
            var res = await _authService.GetInfoGoogle(accessToken ?? "");
            return Ok(res);
        }
        
        [AllowAnonymous]
        [HttpGet("get-redirect-url")]
        public async Task<IActionResult> GetRedirectUrl(int platform, int? type)
        {
            var res = await _authService.GetRedirectUrl(platform, type);
            return Ok(res);
        }
        
        [AllowAnonymous]
        [HttpPost("login-microsoft-token")]
        public  async Task<IActionResult> LoginWithMsToken(LoginWithMsTokenRequest req)
        {
            var res = await _authService.LoginWithMsToken(req.Token, ipAddress, req.Platform, req.Type);
            return Ok(res);
        }
        
        #region CRUD User

        [HttpGet("get-users")]
        public async Task<object> GetUsers(string keyword = "", int pageIndex = 1, int pageSize = 50)
        {
            var res = await _userService.GetList(currentUserId, username, keyword, pageIndex, pageSize);
            return Ok(res);
        }

        [HttpGet("get-detail/{id}")]
        public async Task<object> GetUserDetail(Guid id)
        {
            var res = await _userService.GetDetail(currentUserId, username, id);
            return Ok(res);
        }

        [HttpPost("create")]
        public async Task<object> CreateUser([FromForm] SysAccountRequest req)
        {
            var validationResult = await _validator.ValidateAsync(req);
            if (!validationResult.IsValid)
                return BadRequest(Utils.CreateErrorModel<object>(Common.Constant.StatusCode.DataInputInvalid, validationResult.Errors[0].ErrorMessage));

            var res = await _userService.Create(currentUserId, username, req);
            return Ok(res);
        }

        [HttpPost("update/{id}")]
        public async Task<object> UpdateUser(Guid id, [FromForm] SysAccountRequest req)
        {
            var validationResult = await _validator.ValidateAsync(req);
            if (!validationResult.IsValid)
                return BadRequest(Utils.CreateResponseModel(validationResult.Errors[0].ErrorMessage));

            var res = await _userService.Update(currentUserId, username, id, req);
            return Ok(res);
        }

        [HttpDelete("delete/{id}")]
        public async Task<object> DeleteUser(Guid id)
        {
            var res = await _userService.Delete(currentUserId, username, id);
            return Ok(res);
        }

        [HttpGet("get-info-mine")]
        public async Task<object> GetInfoMine()
        {
            var res = await _userService.GetInfoMine(currentUserId, username);
            return Ok(res);
        }

        #endregion
    }
}
