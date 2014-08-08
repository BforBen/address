using System;
using System.Text.RegularExpressions;

namespace GuildfordBoroughCouncil.Address
{
    public static class PostCode
    {
        internal static string FormatPostCode(Match m)
        {
            try
            {
                return m.ToString().Insert(0, " ");
            }
            catch
            {
                return m.ToString();
            }
        }

        public static string Format(string PostCode)
        {
            if (!String.IsNullOrWhiteSpace(PostCode))
            {
                PostCode = PostCode.Trim().ToUpper();

                // Remove non-alpha characters
                PostCode = Regex.Replace(PostCode, @"\W*", String.Empty);

                //[A-Z]{1,2}[0-9R][0-9A-Z]? [0-9][ABD-HJLNP-UW-Z]{2}
                PostCode = Regex.Replace(PostCode, "[0-9][ABD-HJLNP-UW-Z]{2}", new MatchEvaluator(FormatPostCode));
            }

            return PostCode;
        }
    }
}