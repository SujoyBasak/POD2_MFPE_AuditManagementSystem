using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using AuditBenchmarkModule.Repository;
using AuditBenchmarkModule.Providers;
using AuditBenchmarkModule.Controllers;
using System.Collections.Generic;
using System.Diagnostics;
using AuditBenchmarkModule.Models;
using Moq;
using System.Runtime.CompilerServices;

namespace AuditBenchmarkModule.Testing
{
    public class AuditBenchmarkControllerTest
    { 
        List<AuditBenchmark> ls = new List<AuditBenchmark>();
        [SetUp]
        public void Setup()
        {
            
            ls = new List<AuditBenchmark>()
            {
               new AuditBenchmark
            {
                AuditType="Internal",
                BenchmarkNoAnswers=3
            },
                new AuditBenchmark
            {
                AuditType="SOX",
                BenchmarkNoAnswers=1
            }
            };
        }

        [Test]
        
            public void ProviderTest()
            {

                Mock<IBenchmarkRepo> mock = new Mock<IBenchmarkRepo>();
                mock.Setup(p => p.GetNolist()).Returns(ls);
                BenchmarkProvider cp = new BenchmarkProvider(mock.Object);
                List<AuditBenchmark> result = cp.GetBenchmark();
                Assert.AreEqual(ls.Count,result.Count);
            

        }
        [Test]
        public void ControllerTest()
        {
            Mock<IBenchmarkProvider> mock = new Mock<IBenchmarkProvider>();
            mock.Setup(p => p.GetBenchmark()).Returns(ls);
            AuditBenchmarkController cp = new AuditBenchmarkController(mock.Object);
            OkObjectResult result = cp.Get() as OkObjectResult;
            Assert.AreEqual(200, result.StatusCode);

        }

  
        }
    }
