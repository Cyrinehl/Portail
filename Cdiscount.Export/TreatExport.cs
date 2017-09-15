using Cdiscount.Alm.Sonar.Api.Wrapper;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Projects.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Projects.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Projects.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Measures.Component.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Measures.Component.Response;
using Cdiscount.TFS.Api;
using Cdiscount.TFS.Api.Build.Builds.Parameters;
using Cdiscount.TFS.Api.Build.Builds.Response;
using Cdiscount.TFS.Api.test.runs.Response;
using Cdiscount.TFS.Api.test.runs.Parameters;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Cdiscount.Export
{
    public static class TreatExport
    {
        private static List<Build> builds = new List<Build>();
        public static List<Profile> profiles = new List<Profile>();
        private const string generalFile = @"C:\Users\cyrine.hlioui\Desktop\names.csv";


        public static void GenerateExcelSilo(IConfigurationRoot configuration)
        {
            ExtractProfiles(configuration);
            Treat();
            Console.WriteLine("Excel SILO DONE !!");
            Console.Read();
        }


        public static List<Profile> ExtractProfiles(IConfigurationRoot configuration)
        {
            SonarApiClient SonarClient = new SonarApiClient(configuration);
            List<SonarProject> projects = SonarClient.Projects.Index(null, configuration);

            FillBuildsNamesKeys(projects);
            getTestResultsForBuildsFromTFS(configuration);
            FillProfiles(SonarClient, configuration);
            FillBuildsMetrics(SonarClient, configuration);
            FillBuildProfiles(configuration);

            return profiles;
           
        }

        // Fill the attributes buildName and buildKey of each build of the list builds   
        public static void FillBuildsNamesKeys(List<SonarProject> projects)
        {
            foreach (SonarProject project in projects)
            {
                Build b = new Build();
                b.buildKey = project.Key;
                b.buildName = project.Name;
                builds.Add(b);

            }

        }


        // Fill for each profile: the attributes ProfileName, profileKey and the attributes buildName of profileBuilds 
        public static void FillProfiles( SonarApiClient SonarClient, IConfigurationRoot configuration)
        {
            int NumberOfProfiles;           
            Int32.TryParse(configuration["NumberProfiles"], out NumberOfProfiles);

            for (int number = 0; number < NumberOfProfiles; number++)
            {
                Profile profile = new Profile();
                SonarProjectsArgs SonarProjectsArgs = new SonarProjectsArgs();

                string ProfileKey = "Profiles:" + number + ":Key";
                string ProfileName = "Profiles:" + number + ":ProfileName";

                profile.profileKey = configuration[ProfileKey];
                profile.ProfileName = configuration[ProfileName];

                SonarProjectsArgs.ProfileKey = configuration[ProfileKey];
                SonarProjectsArgs.PageSize = "400";
                SonarQualityProfileProjects SonarQualityProfileProjects = SonarClient.QualityProfiles.Projects(SonarProjectsArgs, configuration);

                             
                foreach (SonarProjet project in SonarQualityProfileProjects.QualityProfileProjects)
                {
                    Build b = new Build();
                    b.buildName = project.Name;
                    profile.profileBuilds.Add(b);
                }

                profiles.Add(profile);

            }            
        }

       
        // Fill the attributes of metrics of each build of the list builds
        public static void FillBuildsMetrics(SonarApiClient SonarClient, IConfigurationRoot configuration)
        {

            SonarComponentArgs SonarComponentArgs = new SonarComponentArgs();
            SonarComponentArgs.MetricKeys = new List<MetricKeys>()  {
                 MetricKeys.bugs,
                 MetricKeys.comment_lines_density,
                 MetricKeys.code_smells,
                 MetricKeys.complexity,
                 MetricKeys.coverage,
                 MetricKeys.duplicated_lines_density,
                 MetricKeys.ncloc,
                 MetricKeys.reliability_rating,
                 MetricKeys.security_rating,
                 MetricKeys.sqale_rating,
                 MetricKeys.vulnerabilities
            };


            foreach (Build b in builds)
            {
                SonarComponentArgs.ComponentKey = b.buildKey;
                ComponentMeasureResponse ComponentMeasureResponse = SonarClient.Measures.Component(SonarComponentArgs, configuration);
                List<ComponentMeasure> measures = ComponentMeasureResponse.SonarComponentMeasures.Measures;
                int count = measures.Count;

                for (int i = 0; i < count; i++)
                {
                    string metric = measures[i].Metric;
                    switch (metric)
                    {
                        case "ncloc":
                            b.size = measures[i].Value;
                            break;

                        case "coverage":                           
                            b.coverage = measures[i].Value.Replace(".", ",") + "%";                                                       
                            break;

                        case "duplicated_lines_density":
                            b.duplication = measures[i].Value.Replace(".",",") + "%";
                            break;

                        case "complexity":
                            b.complexity = measures[i].Value;
                            break;

                        case "comment_lines_density":
                            b.commentLinesDensity = measures[i].Value.Replace(".", ",") + "%";
                            break;
                        case "bugs":
                            b.numberBug = measures[i].Value;
                            break;
                        case "code_smells":
                            b.numberCodeSmells = measures[i].Value;
                            break;

                        case "vulnerabilities":
                            b.numberVulnerabilities = measures[i].Value;
                            break;


                        case "security_rating":
                            b.securityRating = measures[i].Value;
                            break;

                        case "reliability_rating":
                            b.reliabilityRating = measures[i].Value;
                            break;

                        case "sqale_rating":
                            b.sqaleRating = measures[i].Value;
                            break;

                    }

                }

            }


            foreach (Build b in builds)
            {
                if (b.coverage == null)
                {
                    b.coverage = "0" + "%";
                }

            }


        }


        //For each profile: replace each build in profileBuilds with the correspending object in the list builds    
        public static void FillBuildProfiles(IConfigurationRoot configuration)
        {

            int NumberOfProfiles;           
            Int32.TryParse(configuration["NumberProfiles"], out NumberOfProfiles);

            for (int number = 0; number < NumberOfProfiles; number++)
            {
                List<Build> tmpList = profiles[number].profileBuilds;
                int countTmpList = tmpList.Count;

                for (int i = 0; i < countTmpList; i++)
                {
                    profiles[number].profileBuilds[i] = builds.Find(x => x.buildName == profiles[number].profileBuilds[i].buildName); 
                    profiles[number].profileBuilds[i].ProfileName = profiles[number].ProfileName;                   
                }


            }
        }


        public static void getTestResultsForBuildsFromTFS(IConfigurationRoot configuration)
        {
            try
            {

                TfsApiClient TfsApiClient = new TfsApiClient(configuration);

                // get definitions and their ID
                TfsBuildDefinitionsArgs TfsBuildDefinitionsArgs = new TfsBuildDefinitionsArgs();
                TfsBuildDefinitionsArgs.apiVersion = "2.0";
                TfsBuildDefinitionsArgs.type = new List<TFS.Api.Type>()
                {
                    TFS.Api.Type.xaml,
                };
                TfsBuildDefinitionsResponse TfsBuildDefinitionsResponse = TfsApiClient.Builds.Definitions(TfsBuildDefinitionsArgs, configuration);


                //Find the definition that corresponds to the build
                foreach (Build build in builds)
                {
                    Definition Definition = TfsBuildDefinitionsResponse.BuildDefinitions.Find(x => x.Name == build.buildName);

                    if (Definition != null)
                    {

                        // get builds for a definition
                        string id = Definition.Id;
                        TfsBuildBuildsArgs TfsBuildBuildsArgs = new TfsBuildBuildsArgs();
                        TfsBuildBuildsArgs.apiVersion = "2.0";
                        TfsBuildBuildsArgs.definitions = new List<string>
                        {
                          id,
                        };
                        TfsBuildBuildsResponse TfsBuildBuildsResponse = TfsApiClient.Builds.builds(TfsBuildBuildsArgs, configuration);


                        // get the Latest Sonar Build
                        

                        Element element = TfsBuildBuildsResponse.Elements.FirstOrDefault(x => x.BuildNumber.StartsWith("Sonar_") == true );
                        if (element != null)
                        {

                            // get testResults for a build 
                            TfsTestRunsArgs TfsTestRunsArgs = new TfsTestRunsArgs();
                            TfsTestRunsArgs.apiVersion = "2.0";
                            TfsTestRunsArgs.BuildId = element.Id;
                            TfsTestRunsResponse TfsTestRunsResponse = TfsApiClient.Test.Runs(TfsTestRunsArgs, configuration);

                            if (TfsTestRunsResponse.TestResult.Count != 0)
                            {
                                //Fill test attributes of the build

                                build.Totaltests = TfsTestRunsResponse.TestResult[0].Totaltests;
                                build.PassedTests = TfsTestRunsResponse.TestResult[0].PassedTests;

                            }
                            else
                            {
                                build.Totaltests = "0";
                                build.PassedTests = "0";
                            }


                        }                    

                    }


                }


            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table:" + e.Message + "\t" + e.GetType();
               
            }


           
           
        }
     

        //Add a build containing colomn names
        public static void AddTitles()
        {
            Build b = new Build();
            b.buildName = "Services";
            b.ProfileName = "quality profile";
            b.numberBug = "Bugs";
            b.numberCodeSmells = "Code Smells";
            b.numberVulnerabilities = "Number vulnerabilities";
            b.complexity = "Complexity";
            b.commentLinesDensity = "Documentation";
            b.coverage = "Coverage";
            b.duplication = "duplication";
            b.reliabilityRating = "Reliability Rating";
            b.securityRating = "security rating";
            b.sqaleRating = "squale rating";
            b.size = "Number of Lines";
            b.Totaltests = "Total tests";
            b.PassedTests = "Passed Tests";
           

            profiles[0].profileBuilds.Insert(0, b);
        }

        
        //Generate a CSV file
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

        public static void Treat()
        {
            AddTitles();
            var tmp = profiles.SelectMany(p => p.profileBuilds);
            GenerateFile(tmp.Select(r => $"{r.buildName};{r.ProfileName};{r.coverage};{r.size};{r.Totaltests};{r.PassedTests};{r.numberBug};{r.numberCodeSmells};{r.numberVulnerabilities};{r.duplication};{r.complexity};{r.commentLinesDensity};{r.reliabilityRating};{r.securityRating};{r.sqaleRating}"));
        }


       
    }
}