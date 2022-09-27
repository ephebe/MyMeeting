using LightBDD.Core.Configuration;
using LightBDD.Framework.Configuration;
using LightBDD.Framework.Reporting.Formatters;
using LightBDD.XUnit2;
using MyMeeting.services.Meetings.Tests.IntegrationTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: ClassCollectionBehavior(AllowTestParallelization = true)]
[assembly: ConfiguredLightBddScope]
namespace MyMeeting.services.Meetings.Tests.IntegrationTests;

internal class ConfiguredLightBddScopeAttribute : LightBddScopeAttribute
{
    protected override void OnConfigure(LightBddConfiguration configuration)
    {
        // some example customization of report writers
        configuration
            .ReportWritersConfiguration()
            .AddFileWriter<HtmlReportFormatter>(".\\output\\FeaturesReport.html");
    }

    protected override void OnSetUp()
    {
        TestServer.Initialize();
    }

    protected override void OnTearDown()
    {
        TestServer.Dispose();
    }
}
