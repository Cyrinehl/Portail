using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Languages.Parameters
{
    /// <summary>
    /// Arguments to get the list of programming languages
    /// </summary>
    public class SonarLanguagesListArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ps">The size of the list to return, 0 for all languages</param>
        /// <param name="q">A pattern to match language keys/names against</param>
        public SonarLanguagesListArgs(int? ps, string q)
        {
            Ps = ps;
            Q = q;
        }

        /// <summary>
        /// The size of the list to return, 0 for all languages
        /// </summary>
        public int? Ps { get; set; }

        /// <summary>
        /// A pattern to match language keys/names against
        /// </summary>
        public string Q { get; set; }
        
        public override string ToString()
        {
            var result = new StringBuilder();

            if (Ps.HasValue)
            {
                SonarHelpers.AppendUrl(result, "ps", Ps.ToString());
            }
            SonarHelpers.AppendUrl(result, "q", Q);
            return result.Length > 0 ? "?" + result : string.Empty;
        }
    }
}