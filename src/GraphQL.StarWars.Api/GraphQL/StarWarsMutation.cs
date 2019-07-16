using AutoMapper;
using GraphQL.StarWars.Api.GraphQL.Types;
using GraphQL.StarWars.Api.GraphQL.ViewModels;
using GraphQL.StarWars.Repositories.Abstractions;
using GraphQL.Types;

namespace GraphQL.StarWars.Api.GraphQL
{
    public class StarWarsMutation : ObjectGraphType
    {
        public StarWarsMutation(IHumanRepository humanRepository, IMapper mapper)
        {
            Name = "Mutation";

            FieldAsync<HumanType>(
                "createHuman",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<HumanInputType>> {Name = "human"}
                ),
                resolve: async context =>
                {
                    var human = context.GetArgument<Human>("human");
                    var model = mapper.Map<Repositories.Models.Human>(human);
                    await humanRepository.AddAsync(model);
                    return mapper.Map<Human>(model);
                });
        }
    }
}