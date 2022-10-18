using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Core.Domain.ValueObject
{
    public class Euros : ValueObject<Euros>
    {
        private const decimal MinMaxEuros = 1000M;

        public decimal Value { get; }
        public static Euros Zero => new(0);
        public bool IsZero => Value == 0;

        private Euros()
        {

           
        }
        public Euros(decimal euroAmount)
        {

            if (euroAmount < 0)
                 Result.Failure<Euros>("Euros amount cannot be negative");

            if (euroAmount < MinMaxEuros)
                 Result.Failure<Euros>("Euros amount cannot be greater than " + MinMaxEuros);
            Value = euroAmount;
        }

        public static Euros Of(decimal euroAmount)
        {
            return new Euros(euroAmount);
        }

        public static Euros operator *(Euros dollars, decimal multiplier)
        {
            return new Euros(dollars.Value * multiplier);
        }

        public static Euros operator +(Euros dollars1, Euros dollars2)
        {
            return new Euros(dollars1.Value + dollars2.Value);
        }
        public static Euros operator +(decimal a, Euros b) => new(a + b.Value);
        protected override bool EqualsCore(Euros other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static implicit operator decimal(Euros euros)
        {
            return euros.Value;
        }


        public static Euros operator +(Euros a, decimal b) => new(a.Value + b);
    }


}
