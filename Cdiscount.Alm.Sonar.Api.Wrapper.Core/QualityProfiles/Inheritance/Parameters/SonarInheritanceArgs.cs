using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Inheritance.Parameters
{
    /// <summary>
    /// Represents the arguments to get the inheritance of a quality profile
    /// </summary>
    public class SonarInheritanceArgs
    {
         /// <summary>
        /// A quality profile key. Either this parameter, or a combination of profileName + language must be set.
        /// </summary>
        public string ProfileKey { get; set; }

        /// <summary>
        /// A quality profile language. If this parameter is set, profileKey must not be set and profileName must be set to disambiguate
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// A quality profile name. If this parameter is set, profileKey must not be set and language must be set to disambiguate
        /// </summary>
        public string ProfileName { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            SonarHelpers.AppendUrl(result, "profileKey", ProfileKey);
            SonarHelpers.AppendUrl(result, "language", Language);
            SonarHelpers.AppendUrl(result, "profileName", ProfileName);

            return result.Length > 0 ? "?" + result : string.Empty;
        }
    }
}