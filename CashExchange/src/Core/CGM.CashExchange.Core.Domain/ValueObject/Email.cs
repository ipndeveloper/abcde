using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CGM.CashExchange.Core.Domain.ValueObject
{
    public class Email : ValueObject<Email>
    {
        // Obrigatório para funcionar com EF
        protected Email()
        {
        }

        public Email(string address)
        {
            if (string.IsNullOrEmpty(address) || address.Length < 5)
                 Result.Failure<Email>("Euros amount cannot be negative");

            Address = address.ToLower().Trim();
            const string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

            if (!Regex.IsMatch(address, pattern))
                Result.Failure<Email>("Euros amount cannot be negative");

            Verified = false;
            VerificationCode = GenerateVerificationCode();
            VerificationCodeExpireDate = DateTime.UtcNow.AddHours(2);
        }

        public string Address { get; } = string.Empty;
        public bool Verified { get; private set; }
        public string VerificationCode { get; private set; } = string.Empty;
        public DateTime VerificationCodeExpireDate { get; private set; } = DateTime.UtcNow.AddHours(2);

        public void Verify(string verificationCode)
        {
            if (verificationCode != VerificationCode)
                throw new ArgumentException("Código de ativação inválido");

            if (VerificationCodeExpireDate > DateTime.UtcNow)
                throw new ArgumentException("Código de ativação expirado");

            Verified = true;
        }

        public void GenerateNewVerificationCode()
        {
            Verified = false;
            VerificationCode = GenerateVerificationCode();
            VerificationCodeExpireDate = DateTime.UtcNow.AddHours(8);
        }

        public void Expire() => Verified = false;

        private static string GenerateVerificationCode() => Guid.NewGuid().ToString().ToUpper()[..8];

        public static implicit operator string(Email email) => email.Address;

        public static implicit operator Email(string address) => new(address);

        public override string ToString() => Address;


        protected override int GetHashCodeCore()
        {
            return 1;
        }

        protected override bool EqualsCore(Email other)
        {
            return true;
        }
    }
}
