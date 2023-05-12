using Microsoft.Playwright;

namespace test.main.Driver;

public interface IPlaywrightDriver
{
    IAPIRequestContext APIRequestContext { get; }
}

public class PlaywrightDriver : IPlaywrightDriver
{
    private readonly Task<IAPIRequestContext> _requestContext;

    public PlaywrightDriver()
    {
        _requestContext = CreateApiContext();
    }

    private async Task<IAPIRequestContext> CreateApiContext()
    {
        var playwright = await Playwright.CreateAsync();

        return await playwright.APIRequest.NewContextAsync();
    }

    public IAPIRequestContext APIRequestContext => _requestContext.GetAwaiter().GetResult();
}