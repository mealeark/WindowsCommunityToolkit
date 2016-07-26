﻿// ******************************************************************
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THE CODE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE CODE OR THE USE OR OTHER DEALINGS IN THE CODE.
// ******************************************************************
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.Windows.Toolkit;

namespace UnitTests
{
    [TestClass]
    public class HelperUnitTests
    {
        [TestMethod]
        public async Task TestGetPackagedFileAsync()
        {
            using (var stream = await StreamHelper.GetPackagedFileStreamAsync("Assets/Sub/test.txt"))
            {
            }
        }

        [TestMethod]
        public async Task TestReadTextAsString()
        {
            using (var stream = await StreamHelper.GetPackagedFileStreamAsync("Assets/Sub/test.txt"))
            {
                var readText = await stream.ReadTextAsync();
                Assert.IsTrue(readText == "This is my content text");
            }
        }

        [TestMethod]
        public void TestIsInternetAvailable()
        {
            Assert.IsTrue(ConnectionHelper.IsInternetAvailable);
        }

        [TestMethod]
        public void TestIsInternetOnMeteredConnection()
        {
            Assert.IsFalse(ConnectionHelper.IsInternetOnMeteredConnection);
        }

        [TestMethod]
        public void TestStringToColor()
        {
            Assert.IsTrue("Red".ToColor().ToString() == "#FFFF0000");
        }

        [TestMethod]
        public void TestHTMLColorNoAlpha()
        {
            Windows.UI.Color myColor = ColorHelper.ToColor("#3a4ab0");

            Assert.IsTrue( myColor.ToHex().ToString() == "#FF3A4AB0");
        }

        [TestMethod]
        public void TestHTMLColor()
        {
            Windows.UI.Color myColor = ColorHelper.ToColor("#ff3a4ab0");

            Assert.IsTrue(myColor.ToHex().ToString() == "#FF3A4AB0");
        }

        //[TestMethod]
        //public void TestHSLColor()
        //{
        //    Windows.UI.Color myColor = ColorHelper.ToColor("#AABBCC");

        //    HslColor hslColor = myColor.ToHsl();

        //    Assert.IsTrue(  hslColor.A == 1 &&
        //                    hslColor.H == 210 &&
        //                    hslColor.S == 25 &&
        //                    hslColor.L == 73
        //        );
        //}

    }
}
