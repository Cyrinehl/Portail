using Cdiscount.Alm.Sonar.Api.Wrapper;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Components.show.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Components.show.Response;


namespace Cdiscount.Export
{
    public static class TreatExportIssues
    {
        private const string generalFile = @"C:\Users\cyrine.hlioui\Desktop\issues.csv";
        private static List<string> RulesKey = new List<string> { "csharpsquid:S1155", "csharpsquid:S2259", "csharpsquid:S1643" };
        private static List<Issue> issues = new List<Issue>();



        public static void ExtractIssues(IConfigurationRoot configuration)
        {
                     
            List<Profile> list = new List<Profile>();
            list = TreatExport.ExtractProfiles(configuration); //services for the wanted profiles 


            SonarApiClient SonarClient = new SonarApiClient(configuration);          

            SonarIssuesSearchArgs SonarIssuesSearch = new SonarIssuesSearchArgs();
            SonarIssuesSearch.Rules = RulesKey; //issues for the wanted rules

            foreach (Profile profile in list)
            {
                List<Build> tmpList = profile.profileBuilds;
                int countTmpList = tmpList.Count;

                
                for (int i = 0; i < countTmpList; i++)
                {// issues for each service
                   
                   
                    SonarIssuesSearch SonarIssues = new SonarIssuesSearch();
                    SonarIssuesSearch.ProjectKeys.Add(tmpList[i].buildKey);

                    SonarIssues = SonarClient.Issues.Search(SonarIssuesSearch, configuration);

                    // fill list a issue for each service
                    while (SonarIssues.Issues.Count < SonarIssues.Paging.Total)
                    {
                        SonarIssuesSearch.SonarPagingQuery.PageIndex++;
                        SonarIssuesSearch tmp = SonarClient.Issues.Search(SonarIssuesSearch, configuration);
                        foreach (SonarIssue issue in tmp.Issues)
                        {
                            SonarIssues.Issues.Add(issue);
                        }

                    }

                    // fill issues list (the private static variable)
                    foreach (SonarIssue issue in SonarIssues.Issues)
                    {
                        Issue b = new Issue();

                        b.ProfileName = tmpList[i].ProfileName;
                        b.projectName = tmpList[i].buildName;
                        b.RuleKey = issue.RuleKey;
                        b.Severity = issue.Severity;
                        b.Type = issue.Type;
                        b.Assignee = issue.Assignee;
                        b.Line = issue.Line;
                        b.ModuleKey = issue.SubProject;
                        b.fileKey = issue.Component;
                        issues.Add(b);
                    }

                    SonarIssuesSearch.ProjectKeys.Clear();
                }
            
            }
           
            foreach (Issue issue in issues)
            {
                               
                SonarComponentShowArgs SonarComponentShowArgsModule = new SonarComponentShowArgs();
                SonarComponentShowArgs SonarComponentShowArgsFile = new SonarComponentShowArgs();                           

                if ( (String.IsNullOrEmpty(issue.ModuleKey)) )                    
                {

                }
                else
                {
                    SonarComponentShowArgsModule.ComponentKey = issue.ModuleKey;
                    ComponentShowResponse ComponentShowResponseModule = SonarClient.Components.Show(SonarComponentShowArgsModule, configuration);                                      
                    issue.Module = ComponentShowResponseModule.Component.ComponentName;
                }


                if ((String.IsNullOrEmpty(issue.fileKey)))
                {
                }
                else
                {
                    SonarComponentShowArgsFile.ComponentKey = issue.fileKey;
                    ComponentShowResponse ComponentShowResponseFile = SonarClient.Components.Show(SonarComponentShowArgsFile, configuration);                  
                    issue.file = ComponentShowResponseFile.Component.ComponentName;                   
                }

            }
         
        }

        public static void AddTitles()
        {
            Issue b = new Issue();
            b.projectName = "Projects";
            b.ProfileName = "Profiles";
            b.RuleKey = "Rules";
            b.Severity = "Severities";
            b.Type = "Type";
            b.Assignee = "Assignee";
            b.Line = "Line";
            b.Module = "Module";
            b.file = "File";
            issues.Insert(0, b);
        
        }

        
        public static void GenerateFile(IEnumerable<string> lines)
        {
            try
            {
                File.Delete(generalFile);
                File.WriteAllLines(generalFile, lines);
            }
            catch (Exception)
            {
                Console.WriteLine("Problem during file generation.");
            }

        }

        public static void TreatExcel()
        {          
            GenerateFile(issues.Select(r => $"{r.projectName};{r.ProfileName};{r.RuleKey};{r.Severity};{r.Type};{r.Assignee};{r.Line};{r.Module};{r.file}"));
        }

        public static void TreatIssuesExcel(IConfigurationRoot configuration)
        {
            ExtractIssues(configuration);
          
            AddTitles();

            TreatExcel();

            Console.WriteLine("DONE !!");

            Console.ReadKey();

        }

    }
}
