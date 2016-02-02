/*****************************************************************************
 * Program.cs
 * 
 * Assembly.Common program class is used to achieve 100% code coverage of the
 * project.
 * 
 * Copyright © 2015 Nosnitor Corporation
 * 
 * This file is a part of the Carpenter project. Use is defined in the
 * End-User License Agreement provided with this software.
 ****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The Nosnitor.Carpenter.CommonAssembly namespace provides common
/// functionality to the Carpenter project.
/// </summary>
namespace Nosnitor.Carpenter.CommonAssembly
{
    /// <summary>
    /// The Program class is used to achieve 100% code coverage of the project.
    /// </summary>
    public class Program
    {

        /// <summary>
        /// The assembly has been loaded.
        /// </summary>
        /// <remarks>
        /// For code coverage.
        /// </remarks>
        private bool _AssemblyLoaded = true;

        /// <summary>
        /// Publicly expose that the assembly has been loaded.
        /// </summary>
        /// <remarks>
        /// For code coverage.
        /// </remarks>
        public bool AssemblyLoaded
        {
            get { return _AssemblyLoaded; }
        } // AssemblyLoaded property

    } // Program class

} // Nosnitor.Carpenter.CommonAssembly namespace
