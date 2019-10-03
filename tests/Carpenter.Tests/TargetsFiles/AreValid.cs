/*
    Carpenter
    A cross-platform dotnet (.NET) build process helper.

    Copyright © 2015-2019 Nosnitor Corporation, All rights reserved.

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.
*/
// SPDX-License-Identifier: MIT

using Shouldly;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Xunit;

namespace Carpenter.TargetsFiles
{
    /// <summary>
    /// Verifies that targets files included in the project are valid.
    /// </summary>
    public class AreValid
    {
        /// <summary>
        /// The path, relative to the test assembly, where the targets files are located.
        /// </summary>
        private const string relativePath = "Build/";


        /// <summary>
        /// The path to the xml schema.
        /// </summary>
        private const string ruleSetSchema = "Schemas/Microsoft.Build.xsd";

        /// <summary>
        /// Defines the valid rulesets.
        /// </summary>
        /// <returns>Valid rulesets.</returns>
        public static IEnumerable<object[]> ValidTargetsFiles =>
            new List<object[]>
            {
                new object[] { "Carpenter.targets" },
            };

        [Fact]
        public void ContainsOneItem()
        {
            ValidTargetsFiles.Count().ShouldBe(1);
        }

        [Theory]
        [MemberData(nameof(ValidTargetsFiles))]
        public void TheFileExists(string fileName)
        {
            File.Exists($"{relativePath}{fileName}").ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidTargetsFiles))]
        public void TheTargetsFileIsValidXml(string fileName)
        {
            XmlDocument xml = new XmlDocument() { XmlResolver = null };
            XmlReaderSettings settings = new XmlReaderSettings() { XmlResolver = null };
            using (XmlReader reader = XmlReader.Create($"{relativePath}{fileName}", settings))
            {
                xml.Load(reader);
            }
        }

        [Theory]
        [MemberData(nameof(ValidTargetsFiles))]
        public void TheTargetsFileIsValidMsBuild(string fileName)
        {
            XmlDocument xml = new XmlDocument() { XmlResolver = null };
            XmlReaderSettings settings = new XmlReaderSettings() { XmlResolver = null };
            using (XmlReader reader = XmlReader.Create($"{relativePath}{fileName}", settings))
            {
                xml.Load(reader);

                xml.Schemas.Add(null, ruleSetSchema);

                xml.Validate(null);
            }
        }
    }
}
