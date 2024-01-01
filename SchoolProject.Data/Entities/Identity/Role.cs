using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Commons;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities.Identity
{
    public class Role:IdentityRole<int>
    {
        public string NameEn { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public Role()
        {
            Name = NameEn;
        }
        public string Localize(string? TextAr, string? TextEn)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
            {
                return TextAr!;
            }
            return TextEn!;
        }

    }
}
