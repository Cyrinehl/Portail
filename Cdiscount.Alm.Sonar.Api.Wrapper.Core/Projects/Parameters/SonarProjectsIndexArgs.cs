using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Projects.Parameters
{
    public enum VersionsValues
    {
        _true,
        _false,
        _last,
    }

    /// <summary>
    /// Arguments to search for projects
    /// </summary>
    public class SonarProjectsIndexArgs
    {
        /// <summary>
        /// Load project description
        /// </summary>
        public bool? Desc { get; set; }

        /// <summary>
        /// Response json format
        /// </summary>
        public string Format {
            get
            {
                return Constants.Format.Json;
            }
        }

        /// <summary>
        /// Id or key of the project
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Load libraries. Ignored if the parameter key is set
        /// </summary>
        public bool? Libs { get; set; }

        /// <summary>
        /// Substring of project name, case insensitive
        /// </summary>
        public string Search { get; set; }

        /// <summary>
        /// Load sub-projects. Ignored if the parameter key is set
        /// </summary>
        public bool? Subprojects { get; set; }

        /// <summary>
        /// Load version
        /// </summary>
        public VersionsValues? Versions { get; set; }

        /// <summary>
        /// Load views and sub-views. Ignored if the parameter key is set
        /// </summary>
        public bool? Views { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            if (Desc.HasValue)
            {
                SonarHelpers.AppendUrl(result, "desc", Desc.ToString().ToLowerInvariant());
            }
            SonarHelpers.AppendUrl(result, "format", Format);
            SonarHelpers.AppendUrl(result, "key", Key);
            if (Libs.HasValue)
            {
                SonarHelpers.AppendUrl(result, "libs", Libs.ToString().ToLowerInvariant());
            }
            SonarHelpers.AppendUrl(result, "search", Search);
            if (Subprojects.HasValue)
            {
                SonarHelpers.AppendUrl(result, "subprojects", Subprojects.ToString().ToLowerInvariant());
            }
            if (Versions != null)
            {
                SonarHelpers.AppendUrl(result, "versions", Versions.ToString().Substring(1));
            }
            if (Views.HasValue)
            {
                SonarHelpers.AppendUrl(result, "views", Views.ToString().ToLowerInvariant());
            }

            return result.Length > 0 ? "?" + result : string.Empty;
        }
    }
}