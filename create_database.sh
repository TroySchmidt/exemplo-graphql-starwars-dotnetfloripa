#!/bin/bash
rm src/GraphQL.StarWars.Api/starwars.db 
dotnet ef database update --startup-project src/GraphQL.StarWars.Api/ --project src/GraphQL.StarWars.Repositories/
