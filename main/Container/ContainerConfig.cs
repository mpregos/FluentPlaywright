using Autofac;
using test.main.Driver;
using test.main.Operation;

namespace test.main.Container;

public static class ContainerConfig
{
    public static IContainer Configure()
    {
        var build = new ContainerBuilder();

        build.RegisterType<PlaywrightDriver>().As<IPlaywrightDriver>();
        build.RegisterType<ApiOperation>().As<IApiOperation>();

        return build.Build();
    }
}
