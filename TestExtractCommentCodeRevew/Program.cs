using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Discussion.Client;
using Microsoft.TeamFoundation;
using NETExtractComments;

namespace TestExtractCommentCodeRevew
{
    class Program
    {
        static void Main(string[] args)
        {



            int Id = 1292500;
         

            List<CodeReviewComment> comments = ExtractCrComments.CountComments(Id);



        }
    }
}
