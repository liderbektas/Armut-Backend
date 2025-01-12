using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Test_Case.Models;
using Test_Case.Services.Interfaces;

namespace Test_Case.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly LZ_Context _lzContext;

        public UserService(LZ_Context lzContext)
        {
            _lzContext = lzContext;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _lzContext.Users.FindAsync(id);
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            return await _lzContext.Users.ToListAsync();
        }

        public async Task<User> VerifyUserAsync(int id)
        {
            var user = await GetUserByIdAsync(id);
            if (user == null) throw new Exception("User not found");

            user.isVerified = true;
            user.UpdatedAt = DateTime.UtcNow;

            await _lzContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(int id, User model)
        {
            var user = await GetUserByIdAsync(id);
            if (user == null) throw new Exception("User not found");

            user.Name = model.Name;
            user.Email = model.Email;
            user.Phone = model.Phone;
            user.Address = model.Address;
            user.UpdatedAt = DateTime.UtcNow;

            await _lzContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdatePasswordAsync(int id, string currentPassword, string newPassword)
        {
            var user = await GetUserByIdAsync(id);
            if (user == null) throw new Exception("User not found");

            if (user.Password != currentPassword)
                throw new Exception("Mevcut parolanız hatalı");

            if (newPassword.Length < 8)
                throw new Exception("Yeni şifre en az 8 karakterden oluşmalıdır");

            user.Password = newPassword;
            user.UpdatedAt = DateTime.UtcNow;

            await _lzContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> AddPaymentMethodAsync(int id, User model)
        {
            var user = await GetUserByIdAsync(id);
            if (user == null) throw new Exception("User not found");

            if (string.IsNullOrEmpty(model.CreditCardNumber) ||
                string.IsNullOrEmpty(model.CreditCardLastMonth) ||
                string.IsNullOrEmpty(model.CreditCardLastYear) ||
                string.IsNullOrEmpty(model.CreditCardCvvCode))
            {
                throw new Exception("Hiç bir alanı boş bırakmayınız");
            }

            user.CreditCardNumber = model.CreditCardNumber;
            user.CreditCardLastMonth = model.CreditCardLastMonth;
            user.CreditCardLastYear = model.CreditCardLastYear;
            user.CreditCardCvvCode = model.CreditCardCvvCode;
            user.UpdatedAt = DateTime.UtcNow;

            await _lzContext.SaveChangesAsync();
            return user;
        }
    }
}
