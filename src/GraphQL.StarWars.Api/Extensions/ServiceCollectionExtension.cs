using GraphQL.Server;
using GraphQL.StarWars.Api.GraphQL;
using GraphQL.StarWars.Api.GraphQL.Types;
using GraphQL.StarWars.Repositories.Abstractions;
using GraphQL.StarWars.Repositories.Repositories;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.StarWars.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICharacterRepository, CharacterRepository>();
            services.AddTransient<IDroidRepository, DroidRepository>();
            services.AddTransient<IHumanRepository, HumanRepository>();
            services.AddTransient<IEpisodeRepository, EpisodeRepository>();
            services.AddTransient<ITrilogyHeroesRepository, TrilogyHeroesRepository>();
            return services;
        }

        public static IServiceCollection AddGraphTypes(this IServiceCollection services)
        {
            services.AddSingleton<HumanType>();
            services.AddSingleton<HumanInputType>();
            services.AddSingleton<DroidType>();
            services.AddSingleton<CharacterInterface>();
            services.AddSingleton<EpisodeEnum>();
            services.AddTransient<StarWarsQuery>();
            services.AddTransient<StarWarsMutation>();
            return services;
        }

        public static void AddGraphQL(this IServiceCollection services)
        {
            services.AddScoped<ISchema, StarWarsSchema>();
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddGraphQL(_ =>
            {
                _.EnableMetrics = true;
                _.ExposeExceptions = true;
            }).AddUserContextBuilder(httpContext => new GraphQLUserContext {User = httpContext.User});
        }
    }
}