using Autofac;
using test.main.Container;
using test.main.Operation;

namespace test;

public class Tests
{

    IApiOperation apiOperation; 

    [SetUp]
    public void Setup()
    {
        TestContext.Progress.WriteLine("Initialize beans");

        using (var scope = ContainerConfig.Configure().BeginLifetimeScope())
        {
            apiOperation = scope.Resolve<IApiOperation>();
        }
    }

    [Test]
    public async Task Test1()
    {
        var resp = await apiOperation
            .Create()
            .WithUrl("https://api.publicapis.org/entries")
            .GetAsync();
        Assert.That(resp.Ok, Is.True);
        var text = await resp.JsonAsync();
        TestContext.Progress.WriteLine($"Result : {text}");
        Assert.Pass();
    }
}