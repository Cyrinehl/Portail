using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Users.Groups.Parameters
{
    public enum SelectedValues
    {
        selected,
        deselected,
        all
    }

    /// <summary>
    /// Membership information to search a user group
    /// </summary>
    public class SonarUserGroupsUsersArgs
    {
        /// <summary>
        /// Group id
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Group name
        /// </summary>
        public string Name { get; set; }

        public SonarPagingQuery SonarPagingQuery { get; set; }

        /// <summary>
        /// Limit search to names or logins that contain the supplied string.
        /// </summary>
        public string Q { get; set; }

        /// <summary>
        /// Depending on the value, show only selected items (selected=selected)
        /// deselected items (selected=deselected), or all items with their selection status (selected=all).
        /// </summary>
        public SelectedValues? Selected { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            if (Id.HasValue)
            {
                SonarHelpers.AppendUrl(result, "id", Id.ToString());
            }
            SonarHelpers.AppendUrl(result, "name", Name);
            if (SonarPagingQuery != null)
            {
                result.Append(SonarPagingQuery.ToString());
            }
            SonarHelpers.AppendUrl(result, "q", Q);
            if (Selected.HasValue)
            {
                SonarHelpers.AppendUrl(result, "selected", Selected.ToString());
            }

            return result.Length > 0 ? "?" + result : string.Empty;
        }
    }
}