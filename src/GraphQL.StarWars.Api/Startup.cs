using System;
using AutoMapper;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.StarWars.Api.Extensions;
using GraphQL.StarWars.Repositories;
using GraphQL.StarWars.Repositories.Seed;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.StarWars.Api
{
    public class Startup : IStartup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(_ => { }, GetType().Assembly);

            services.AddDbContext<StarWarsContext>(opt =>
            {
                opt.UseSqlite("Data Source=starwars.db",
                    b => b.MigrationsAssembly("GraphQL.StarWars.Repositories"));
            });

            ServiceCollectionExtension.AddGraphQL(services.AddRepositories()
                    .AddGraphTypes());

            return services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app)
        {
            var db = app.ApplicationServices.GetService<StarWarsContext>();
            db.EnsureSeedData();

            app.UseDeveloperExceptionPage();

            app.UseGraphQL<ISchema>();

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                Path = "/api-docs/playground"
            });
        }
    }
}