﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Restaurant.Application.Models;
using Restaurant.Application.Models.Identities;
using Restaurant.Application.Models.Identities.JWTSettings;
using Restaurant.Domain.Entities.Identity;
using Restaurant.Infrastructure.DbContexts;

namespace Restaurant.Application.Services.IdentityServices
{
    public class IdentityService : IIdentityService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly JWTSetting _jwtSetting;

        public IdentityService(
            AppDbContext context,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IOptions<JWTSetting> jwtSetting)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _jwtSetting = jwtSetting.Value;
        }

        public async Task<Response> ChangeUserPassword(ChangePassword changePassword)
        {
            var user = await _userManager.FindByNameAsync(changePassword.Username);

            if (user == null)
                return new Response
                {
                    Status = Statuses.Error,
                    Message = "User not found"
                };

            var result = await _userManager
                .ChangePasswordAsync(user, changePassword.Password, changePassword.PasswordOld);

            return new Response { Status = Statuses.Success, Message = "Password changed successfully" };
        }

        public async Task<TokenModel> ChooseMainRole(MainRole mainRole)
        {
            var user = await _userManager.FindByNameAsync(mainRole.Username);

            if (user == null)
                return null!;

            var isInRole = await _userManager.IsInRoleAsync(user, mainRole.Role);

            if (!isInRole)
                return null!;

            var role = await _roleManager.FindByNameAsync(mainRole.Role);

            user.MainRoleId = role!.Id;

            var result = await _userManager.UpdateAsync(user);

            return await TokenExtension.GetToken(user, _userManager, _roleManager, _jwtSetting);
        }

        public async Task<TokenModel> Login(Login loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);

            if (user == null)
                throw new Exception("Username or Password invalid !");

            if (user.LockoutEnabled)
                throw new Exception("User Locked out !");

            var isPasswordValid = await _userManager
                .CheckPasswordAsync(user, loginDto.Password);

            if (!isPasswordValid)
                throw new Exception("Username or Password invalid !");

            return await TokenExtension.GetToken(user, _userManager, _roleManager, _jwtSetting);
        }

        public async Task<Response> LockOutUser(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
                return new Response
                {
                    Status = Statuses.Error,
                    Message = "User not found"
                };

            var isLogedOut = await _userManager.SetLockoutEnabledAsync(user, true);

            return isLogedOut.Succeeded
                ? new Response { Status = Statuses.Success, Message = "OK" }
                : new Response { Status = Statuses.Error, Message = "Error" };
        }

        public async Task<Response> UnLockOutUser(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
                return new Response
                {
                    Status = Statuses.Error,
                    Message = "User not found"
                };

            var isUnlocked = await _userManager.SetLockoutEnabledAsync(user, false);

            return isUnlocked.Succeeded
                ? new Response { Status = Statuses.Success, Message = "OK" }
                : new Response { Status = Statuses.Error, Message = "Error" };
        }

        public async Task<TokenModel> RefreshAccessToken(UserDto userDto)
        {
            var user = await _userManager.FindByNameAsync(userDto.UserName);

            if (user == null)
                return null!;

            return await TokenExtension.GetToken(user, _userManager, _roleManager, _jwtSetting);
        }

        public async Task<Response> Register(Register registerDto)
        {
            var existingUser = await _userManager.FindByNameAsync(registerDto.Username);

            if (existingUser != null)
                return new Response
                {
                    Status = Statuses.Error,
                    Message = "User already exists"
                };

            var role = await _roleManager.FindByIdAsync(registerDto.MainRoleId);

            if (role == null)
                return new Response() { Message = "Role is not found", Status = Statuses.Error };

            var newUser = new ApplicationUser
            {
                FullName = registerDto.Fullname,
                Email = registerDto.Email,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                UserName = registerDto.Username,
                LockoutEnabled = false,
                LastActive = DateTime.UtcNow,
                MainRoleId = role!.Id
            };

            var isRegistered = await _userManager.CreateAsync(newUser, registerDto.Password);

            await AddUserToRole(role?.Name!, newUser);

            return isRegistered.Succeeded
               ? new Response { Status = Statuses.Success, Message = "Successfully registered" }
               : new Response { Status = Statuses.Error, Message = "Registration failed ! " };
        }

        private async Task<Response> AddUserToRoles(IEnumerable<string> roles, ApplicationUser user, UserDto currentUser)
        {
            bool userCanCreateRole = RestaurantAdmin.Managers.Contains(currentUser.UserName.ToLower());

            var rolesOfUser = await _userManager.GetRolesAsync(user);

            if (userCanCreateRole)
            {
                await _userManager.RemoveFromRolesAsync(user, rolesOfUser);
                var result = await _userManager.AddToRolesAsync(user, roles);
                if (result.Succeeded)
                    return new Response { Status = Statuses.Success, Message = "Ok" };
            }


            return new Response
            {
                Status = Statuses.Error,
                Message = "Something went wrong while adding role !"
            };
        }

        private async Task<Response> AddUserToRole(string role, ApplicationUser user)
        {

            var rolesOfUser = await _userManager.GetRolesAsync(user);

            await _userManager.RemoveFromRolesAsync(user, rolesOfUser);

            rolesOfUser.Add(role);

            var result = await _userManager.AddToRolesAsync(user, rolesOfUser);
            if (result.Succeeded)
                return new Response { Status = Statuses.Success, Message = "Ok" };


            return new Response
            {
                Status = Statuses.Error,
                Message = "Something went wrong while adding role !"
            };
        }

        public async Task<UserDto> UpdateUser(UserDto userDto)
        {
            var existingUser = await _userManager.FindByIdAsync(userDto.Id.ToString());

            if (existingUser == null)
                throw new Exception("User not found");

            existingUser.UserName = userDto.UserName;
            existingUser.Email = userDto.Email;
            existingUser.PhoneNumber = userDto.PhoneNumber;
            existingUser.FullName = userDto.FullName;
            existingUser.LastActive = DateTime.UtcNow;

            var isUpdated = await _userManager.UpdateAsync(existingUser);

            return isUpdated.Succeeded
                ? userDto
                : null!;
        }

        public async Task<bool> IsUserExists(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            return user is not null ? true : false;
        }

        public async Task<Response> AddRolesToUser(int userId, List<string> roles, UserDto userDto)
        {
            var Adder = await _userManager.FindByNameAsync(userDto.UserName);

            var manager = await _roleManager.FindByNameAsync(Roles.Manager);

            var isManager = Adder!.MainRoleId == manager!.Id;

            if (!isManager)
                return new Response
                {
                    Status = Statuses.Error,
                    Message = "Only Manager can add roles"
                };

            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
                return new()
                {
                    Status = Statuses.Error,
                    Message = "User not found"
                };

            var oldRoles = await _userManager.GetRolesAsync(user);

            await _userManager.RemoveFromRolesAsync(user, oldRoles);

            var isAdded = await _userManager.AddToRolesAsync(user, roles);

            return isAdded.Succeeded
                ? new Response { Status = Statuses.Success, Message = "Roles added successfully" }
                : new Response { Status = Statuses.Error, Message = "Adding roles failed !" };
        }

        public async Task<string> GetMainRole(int mainRoleId)
        {
            if (mainRoleId <= 0)
                return await Task.FromResult("");

            var role = await _roleManager.Roles
                .FirstOrDefaultAsync(x => x.Id == mainRoleId);

            return await Task.FromResult(role?.Name!);
        }
    }
}
