using System.Security.Claims;

namespace GraphQL.StarWars.Api.GraphQL
{
    public class GraphQLUserContext
    {
        public ClaimsPrincipal User { get; set; }
    }
}