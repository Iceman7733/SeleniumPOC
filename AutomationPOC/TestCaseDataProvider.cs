using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationPOC.TestCaseObjects;
using NUnit.Framework;
using Newtonsoft.Json;


namespace AutomationPOC
{
    public static class TestCaseDataProvider
    {
        private static string _baseFilePath =
            @"C:\Users\burchettj\source\repos\AutomationPOC\AutomationPOC\TestCasesJSON\";
        public static List<TestCaseData> LoginTestCaseData
        {
            get
            {
                var testCases =
                    JsonConvert.DeserializeObject<List<LoginPageTestCase>>(File.ReadAllText(_baseFilePath + "LoginTestCase.json"));
                var testCaseData = new List<TestCaseData>();
                foreach (var testCase in testCases)
                {
                    testCaseData.Add(new TestCaseData(testCase));
                }

                return testCaseData;
            }
        }
    }
}
