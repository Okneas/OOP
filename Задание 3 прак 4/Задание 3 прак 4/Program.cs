using System;

namespace Задание_3_прак_4
{
    // Enumerations Exercise 1
    /// <summary>
    /// Enumeration of girder material types
    /// </summary>
    public enum Material { StainlessSteel, Aluminium, ReinforcedConcrete, Composite, Titanium }
    /// <summary>
    /// Enumeration of girder cross-sections
    /// </summary>
    public enum CrossSection { IBeam, Box, ZShaped, CShaped }
    /// <summary>
    /// Enumeration of test results
    /// </summary>
    public enum TestResult { Pass, Fail }
    // Structures Exercise 2
    /// <summary>
    /// Structure containing test results
    /// </summary>
    public struct TestCaseResult
    {
        /// <summary>
        /// Test result (enumeration type)
        /// </summary>
        public TestResult Result;
        /// <summary>
        /// Description of reason for failure
        /// </summary>
        public string ReasonForFailure;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Material mat = new Material();
            CrossSection cs = new CrossSection();
            TestCaseResult[] results = new TestCaseResult[10];
            Random a = new Random();
            for(int i=0; i<results.Length; i++)
            {
                switch(a.Next(0, 4))
                {
                    case 0:
                        mat = Material.Aluminium;
                        break;
                    case 1:
                        mat = Material.Composite;
                        break;
                    case 2:
                        mat = Material.ReinforcedConcrete;
                        break;
                    case 3:
                        mat = Material.StainlessSteel;
                        break;
                    case 4:
                        mat = Material.Titanium;
                        break;
                }
                switch (a.Next(0, 3))
                {
                    case 0:
                        cs = CrossSection.IBeam;
                        break;
                    case 1:
                        cs = CrossSection.Box;
                        break;
                    case 2:
                        cs = CrossSection.ZShaped;
                        break;
                    case 3:
                        cs = CrossSection.CShaped;
                        break;
                }
                if(mat == Material.Aluminium && cs == CrossSection.IBeam)
                {
                    results[i].Result = TestResult.Fail;
                    results[i].ReasonForFailure = "Because Aluminum Ibeam";
                }
                else if (mat == Material.Titanium && cs == CrossSection.CShaped)
                {
                    results[i].Result = TestResult.Fail;
                    results[i].ReasonForFailure = "Because Titanium CShaped";
                }
                else if (mat == Material.StainlessSteel && cs == CrossSection.Box)
                {
                    results[i].Result = TestResult.Fail;
                    results[i].ReasonForFailure = "Because StainlessSteel Box";
                }
                else if (mat == Material.ReinforcedConcrete && cs == CrossSection.ZShaped)
                {
                    results[i].Result = TestResult.Fail;
                    results[i].ReasonForFailure = "Because ReinforcedConcrete ZShaped";
                }
                else if (mat == Material.Composite && cs == CrossSection.IBeam)
                {
                    results[i].Result = TestResult.Fail;
                    results[i].ReasonForFailure = "Because Composite IBeam";
                }
                else
                {
                    results[i].Result = TestResult.Pass;
                }
            }
            for (int i = 0; i < results.Length; i++)
            {
                if (results[i].Result == TestResult.Fail)
                {
                    Console.WriteLine($"Reason For Failure: {results[i].ReasonForFailure}");
                }
                else
                {
                    Console.WriteLine("Success!");
                }
            }
        }
    }
}
