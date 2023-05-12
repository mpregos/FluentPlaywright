using Microsoft.Playwright;
using test.main.Driver;

namespace test.main.Operation;

public interface IApiOperation
{
    ApiOperation Create();
    Task<IAPIResponse> PostAsync();

    Task<IAPIResponse> GetAsync();
    ApiOperation WithHeader(string key, string value);
    ApiOperation WithParameters(string key, string value);
    ApiOperation WithUrl(string url);
}

public class ApiOperation : IApiOperation
{
    protected IPlaywrightDriver driver;
    string url;
    Dictionary<string, object> parameters;
    Dictionary<string, string> headers;

    public ApiOperation(IPlaywrightDriver playwrightDriver)
    {
        driver= playwrightDriver;
    }

    public ApiOperation Create()
    {
        parameters = new Dictionary<string, object>();
        headers = new Dictionary<string, string>();
        return this;
    }

    public ApiOperation WithParameters(string key, string value)
    {
        parameters[key] = value;
        return this;
    }

    public ApiOperation WithHeader(string key, string value)
    {
        headers[key] = value;
        return this;
    }

    public ApiOperation WithUrl(string url)
    {
        this.url = url;
        return this;
    }

    public async Task<IAPIResponse> PostAsync()
    {
        var response = await driver.APIRequestContext.PostAsync(url, new APIRequestContextOptions()
        {
            Headers = headers,
            Params = parameters
        });

        return response;
    }

    public async Task<IAPIResponse> GetAsync()
    {
        var response = await driver.APIRequestContext.GetAsync(url, new APIRequestContextOptions()
        {
            Headers = headers,
            Params = parameters
        });

        return response;
    }
}
