using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rpg_project.Data;
using Rpg_project.Models;

namespace Rpg_project.Services.AuthService
{
    public class AuthService : IAuthService
    {

        public DataContext _context { get; }

        public AuthService(DataContext context)
        {
            _context = context;

        }
        public async Task<bool> CheckIfExists(string email)
        {
            if (await _context.Users.AnyAsync(x => x.Email.ToLower().Equals(email.ToLower())))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public async Task<ServiceResponse<bool>> Login(string email, string password)
        {

            var serviceResponse = new ServiceResponse<bool>();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Invalid Email";
                return serviceResponse;
            }

            if (VerifyPassword(password, user.PasswordHash, user.PasswordSalt) == false)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = "Invalid Password";
                return serviceResponse;
            }

            serviceResponse.Message = "Logged In Successfully!";
            serviceResponse.Data = true;
            return serviceResponse;


        }

        public async Task<ServiceResponse<int>> Register(string email, string password)
        {
            var serviceResponse = new ServiceResponse<int>();
            try
            {

                GeneratePassword(password, out byte[] passwordHash, out byte[] passwordSalt);

                var user = new Users();

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Email = email;

                if (await CheckIfExists(email))
                {

                    serviceResponse.Message = "User already exists";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                _context.Users.Add(user);

                await _context.SaveChangesAsync();

                serviceResponse.Data = user.Id;

                return serviceResponse;
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                return serviceResponse;
            }

        }

        // a void method, without return type -- we use out here, which returns the value.
        private void GeneratePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {

            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {

                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }

                }
                return true;
            }

        }

    }
}