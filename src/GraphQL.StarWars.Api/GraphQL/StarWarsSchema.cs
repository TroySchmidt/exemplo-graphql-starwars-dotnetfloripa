using GraphQL.Types;

namespace GraphQL.StarWars.Api.GraphQL
{
    public class StarWarsSchema : Schema
    {
        public StarWarsSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<StarWarsQuery>();
            Mutation = resolver.Resolve<StarWarsMutation>();
        }
    }
}