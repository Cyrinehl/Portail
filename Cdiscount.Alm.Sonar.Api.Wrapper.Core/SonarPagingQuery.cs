using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core
{
    public class SonarPagingQuery
    {
        private int? _pageIndex;
        private int? _pageSize;

        /// <summary>
        /// 1-based page number
        /// </summary>
        public int PageIndex
        {
            get
            {
                if (!_pageIndex.HasValue)
                {
                    _pageIndex = 1;
                }
                return _pageIndex.Value;
            }
            set
            {
                _pageIndex = value;
            }
        }

        private const int MAX_SONAR_PAGE_SIZE = 500;

        /// <summary>
        /// Page size. Must be greater than 0 and less than 500
        /// </summary>
        public int? PageSize
        {
            get { return _pageSize; }
            set
            {
                if (value < 0 || value > MAX_SONAR_PAGE_SIZE)
                {
                    throw new ArgumentException("PageSize Must be greater than 0 and less than 500");
                }
                else
                {
                    _pageSize = value;
                }
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var result = new StringBuilder();

            if (PageSize != null)
            {
                SonarHelpers.AppendUrl(result, "ps", PageSize.Value.ToString());
            }
            if (PageIndex != 0)
            {
                SonarHelpers.AppendUrl(result, "p", PageIndex.ToString());
            }

            return result.Length > 0 ? result.ToString() : string.Empty;
        }
    }
}