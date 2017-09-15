using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityGates.Parameters
{

    public enum SelectedValues
    {
        selected,
        deselected,
        all
    }

    /// <summary>
    /// Represents arguments to search projects associated (or not) to a quality gate.
    /// </summary>
    public class SonarQualityGatesSearchArgs
    {
        /// <summary>
        /// Create arguments
        /// </summary>
        /// <param name="gateId">Quality Gate ID</param>
        public SonarQualityGatesSearchArgs(int gateId)
        {
            GateId = gateId;
        }

        /// <summary>
        /// Quality Gate ID
        /// </summary>
        public int GateId { get; set; }

        private int? _page;

        /// <summary>
        /// Page number, default 1
        /// </summary>
        public int Page
        {
            get
            {
                if (!_page.HasValue)
                {
                    _page = 1;
                }
                return _page.Value;
            }
            set { _page = value; }
        }

        private int? _pageSize;

        /// <summary>
        /// Page size, default 100
        /// </summary>
        public int PageSize
        {
            get
            {
                if (!_pageSize.HasValue)
                {
                    _pageSize = 100;
                }
                return _pageSize.Value;
            }
            set
            {
                _pageSize = value;
            }
        }

        /// <summary>
        /// To search for projects containing this string. If this parameter is set, "selected" is set to "all".
        /// </summary>
        public string Query { get; set; }

        private SelectedValues? _selected;

        /// <summary>
        /// Depending on the value, 
        /// show only selected items (selected=selected), 
        /// deselected items (selected=deselected), 
        /// or all items with their selection status (selected=all).
        /// </summary>
        public SelectedValues Selected
        {
            get
            {
                if (!_selected.HasValue)
                {
                    _selected = SelectedValues.selected;
                }
                return _selected.Value;
            }
            set { _selected = value; }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            SonarHelpers.AppendUrl(result, "gateId", GateId.ToString());
            SonarHelpers.AppendUrl(result, "page", Page.ToString());
            SonarHelpers.AppendUrl(result, "pageSize", PageSize.ToString());
            SonarHelpers.AppendUrl(result, "query", Query);
            SonarHelpers.AppendUrl(result, "selected", Selected.ToString());

            return result.Length > 0 ? "?" + result : string.Empty;
        }
    }
}