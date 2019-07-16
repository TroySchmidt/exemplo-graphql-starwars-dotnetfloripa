using GraphQL.StarWars.Api.GraphQL.ViewModels;
using GraphQL.Types;

namespace GraphQL.StarWars.Api.GraphQL.Types
{
    public class HumanInputType : InputObjectGraphType<Human>
    {
        public HumanInputType()
        {
            Name = "HumanInput";
            Field(x => x.Name);
            
        }
    }
}