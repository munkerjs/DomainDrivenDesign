using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Shared
{
    public sealed record Currency
    {
        internal static readonly Currency None = new ("");
        public static readonly Currency Usd = new("USD");
        public static readonly Currency Try = new("TRY");
        public string Code { get; init; }

        public Currency(string code)
        {
            Code = code;
        }

        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault(x => x.Code == code) ?? throw new ArgumentException("Geçerli bir para birimi giriniz.");
        }

        public static readonly IReadOnlyCollection<Currency> All = new[] { Usd, Try };
    }
}
