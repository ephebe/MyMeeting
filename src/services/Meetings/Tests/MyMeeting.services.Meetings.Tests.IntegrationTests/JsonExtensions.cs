using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.services.Meetings.Tests.IntegrationTests;

internal static class JsonExtensions
{
    public static HttpContent ToJsonContent(this object payload)
    {
        return new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
    }

    public static async Task<T> DeserializeAsync<T>(this HttpResponseMessage response)
    {
        return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
    }
}
