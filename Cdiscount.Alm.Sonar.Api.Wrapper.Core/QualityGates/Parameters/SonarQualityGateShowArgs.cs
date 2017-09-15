using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityGates.Parameters
{
    /// <summary>
    /// Arguments to show the details of a quality gate
    /// </summary>
    public class SonarQualityGateShowArgs
    {
        /// <summary>
        /// Create arguments to show the details of a quality gate 
        /// Either id or name must be set
        /// </summary>
        /// <param name="id">ID of the quality gate</param>
        /// <param name="name">Name of the quality gate</param>
        public SonarQualityGateShowArgs(int? id, string name)
        {
            Id = id;
            Name = name;
        }

        public SonarQualityGateShowArgs(int? id) : this(id, null) { }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SonarQualityGateShowArgs() : this(null) { }

        /// <summary>
        /// ID of the quality gate
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Name of the quality gate
        /// </summary>
        public string Name { get; set; }
        
        public override string ToString()
        {
            var result = new StringBuilder();

            if (Id.HasValue)
            {
                SonarHelpers.AppendUrl(result, "id", Id.ToString());
            }
            SonarHelpers.AppendUrl(result, "name", Name);

            return result.Length > 0 ? "?" + result : string.Empty;
        }
    }
}