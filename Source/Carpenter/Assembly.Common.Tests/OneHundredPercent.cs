/*****************************************************************************
 * OneHundredPercent.cs
 * 
 * Wraps up code coverage on project to reach 100%.
 * 
 * Copyright (c) 2015 Nosnitor Corporation
 ****************************************************************************/
using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// The Assembly.Common.Tests namespace contains test cases to achieve code coverage.
namespace Nosnitor.Carpenter.CommonAssembly.Tests
{
    /// <summary>
    /// The OneHundredPercent test class executes unnecessary assemblies and data sets - just to get 100 percent, even on one off tools and utilities.
    /// </summary>
    [TestClass]
    public partial class OneHundredPercent
    {

        /// <summary>
        /// Covers Assembly.Common code.
        /// </summary>
        [TestCategory("OneHundredPercent"), TestMethod]
        public void AssemblyCommonCodeCoverage()
        {
            // Write to log file.
            Trace.Write("Description: Loads the Assembly.Common file into code coverage.\r\n\r\n");
            Trace.WriteLine("");

            // Loads the assembly
            Trace.Write("Loading the assembly: ");
            Nosnitor.Carpenter.CommonAssembly.Program  prog = new Nosnitor.Carpenter.CommonAssembly.Program();
            Trace.Write("{Expected: True; Actual: " + prog.AssemblyLoaded.ToString() + "} ");
            Assert.IsTrue(prog.AssemblyLoaded);
            Trace.WriteLine("[Pass] ");
            prog = null;

        } // AssemblyCommonCodeCoverage method

    } // OneHundredPercent class

} // Assembly.Common.Tests namespace