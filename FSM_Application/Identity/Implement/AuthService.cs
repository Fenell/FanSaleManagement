using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FSM_Application.Identity.Interface;
using FSM_Data.Entities.Authen;
using FSM_ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FSM_Application.Identity.Implement;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<string> Login(string username, string password)
    {
        //Kiểm tra trong Db có thằng này k
        var userExists = await _userManager.FindByNameAsync(username);

        // Nếu có thì đăng nhập 
        if (userExists == null)
        {
            return "";
        }

        var result = await _signInManager.PasswordSignInAsync(userExists, password, false, false);

        // Trả về Token dưới dạng string
        var jwt = await GenerateToken(userExists);
        var token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return token;
    }

    public async Task<RegisterReponse> Register(RegisterRequest request)
    {
        var user = new ApplicationUser()
        {
            UserName = request.UserName,
            FirstName = request.FirstName,
            LastName = request.LastName,
        };

        var userExists = await _userManager.FindByNameAsync(request.UserName);
        if (userExists != null)
            return new RegisterReponse() { IsSuccess = false, Message = "Tài khoản đã tồn tại" };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");
            return new RegisterReponse(){IsSuccess = true, Message = "Đăng ký thành công"};
        }

        var response = new RegisterReponse();
        response.IsSuccess = false;
        foreach (var error in result.Errors)
        {
            response.Message += error.Description+ Environment.NewLine;
        }
        return response;
    }

    private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
    {
        //Lấy ra thông tin user
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        //Chuyển các thông tin user sang Claims
        var rolesClaim = roles.Select(c => new Claim(ClaimTypes.Role, c)).ToList();
        var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("lol", user.Id)
            }
            .Union(userClaims)
            .Union(rolesClaim);

        //Tạo khóa bảo mật đối xứng
        var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));

        //tạo khóa ký = cách chuyển chuỗi symetricSecurityKey băm  sang Sha256, Sha512,...
        var signingCredential = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);

        //tạo JWT
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(5),
            signingCredentials: signingCredential);

        return jwtSecurityToken;
    }
}