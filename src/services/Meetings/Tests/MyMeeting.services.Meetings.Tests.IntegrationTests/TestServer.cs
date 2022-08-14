using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.services.Meetings.Tests.IntegrationTests;

internal static class TestServer
{
    private static WebApplicationFactory<Program> Instance { get; set; }

    public static HttpClient GetClient() => Instance?.CreateDefaultClient()
       ?? throw new InvalidOperationException($"{nameof(TestServer)} not initialized.");

    public static void Initialize()
    {
        Instance = new WebApplicationFactory<Program>();
        // Actually the WebApplicationFactory has a problem that until CreateDefaultClient() is called, no underlying TestServer instance is created.
        // Also, the underlying TestServer creation has a race condition, calling it from tests running in parallel may cause multiple servers to be spawned.
        Instance.CreateDefaultClient();
    }

    public static void Dispose() => Instance.Dispose();
}
