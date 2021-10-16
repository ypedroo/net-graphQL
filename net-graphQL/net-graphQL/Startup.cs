using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using net_graphQL.Database;
using net_graphQL.GraphQL;

namespace net_graphQL
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TimeGraphContext>(context => { context.UseInMemoryDatabase("TimeGraphServer"); });
            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<Types.ProjectType>()
                .AddType<Types.TimeLogType>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UsePlayground(new PlaygroundOptions
                {
                    QueryPath = "/api",
                    Path = "/playground"
                });
            }

            app.UseWebSockets();
            app
                .UseRouting()
                .UseEndpoints(endpoints => { endpoints.MapGraphQL(); });
        }
    }
}