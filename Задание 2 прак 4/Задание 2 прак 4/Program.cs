using System;

namespace Задание_2_прак_4
{
    /// <summary>
    /// Enumeration of girder material types
    /// </summary>
    public enum Material
    {
        StainlessSteel,
        Aluminium,
        ReinforcedConcrete,
        Composite,
        Titanium
    }
    /// <summary>
    /// Enumeration of girder cross-sections
    /// </summary>
    public enum CrossSection
    {
        IBeam,
        Box,
        ZShaped,
        CShaped
    }
    /// <summary>
    /// Enumeration of test results
    /// </summary>
    public enum TestResult
    {
        Pass,
        Fail
    }

    class Program
    {
        static void Main(string[] args)
        {
            Material mat = Material.Composite;
            CrossSection cs = CrossSection.ZShaped;
            TestResult res = TestResult.Pass;
            string a = "";
            switch (mat)
            {
                case (Material.StainlessSteel):
                    a += "StainlessSteel ";
                    break;
                case (Material.Aluminium):
                    a += "Aluminium ";
                    break;
                case (Material.ReinforcedConcrete):
                    a += "ReinforcedConcrete ";
                    break;
                case (Material.Composite):
                    a += "Composite ";
                    break;
                case (Material.Titanium):
                    a += "Titanium ";
                    break;
            }
            switch (cs)
            {
                case (CrossSection.IBeam):
                    a += "IBeam ";
                    break;
                case (CrossSection.Box):
                    a += "Box ";
                    break;
                case (CrossSection.ZShaped):
                    a += "ZShaped ";
                    break;
                case (CrossSection.CShaped):
                    a += "CShaped ";
                    break;
            }
            switch (res)
            {
                case (TestResult.Pass):
                    a += "Pass ";
                    break;
                case (TestResult.Fail):
                    a += "Fail ";
                    break;
            }
            Console.WriteLine(a);
        }
    }
}
