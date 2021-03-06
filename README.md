# <div align="center">Kodesonen Hackathon April 2021 <br/> Kategori 3 - API-Utvikling <br/>Alternativ 2
Dette er mitt bidrag til kodesonen sin [hackathon](https://github.com/kodesonen/arrangementer/tree/main/hackathon-2021). Jeg har laget et api med C# .NET core. Jeg begynte med ASP.NET Core Web API template og fulgte denne [guiden](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-5.0&tabs=visual-studio) for å lære hvordan det fungerer.
## Endpoints
Jeg har laget 4 endpoints:
* [GET] /api/AvreageAge Returnerer snittalder på medlemmer
* [PUT] /api/MemberMajor/{id} Oppdaterer hvilket studie medlem er registrert på
* [GET] /api/MemberMajor/percentDATAING Returnerer prosentandel dataingeniører
* [GET] /api/NumberOfMembers - Returnerer antall medlemmer  
For mer detaljert info så kan du kjøre sln også kommer swagger siden opp på oppstart.
## Kobling til Database(MySQL)
På filen [dbStuff.cs](https://github.com/jorri11/APIOppgave2/blob/main/HackathonAPI/dbStuff.cs) kan du konfigurere tilkoblingen til databasen. dette skjer i myConnectionString i connectdb() metoden.   
Jeg har også prøvd meg på en slags caching av dataene, så spørringene blir ikke kjørt mot databasen hver gang. Dette kan du se i [CachedDataTable.cs](https://github.com/jorri11/APIOppgave2/blob/main/HackathonAPI/CachedDataTable.cs)   
Tabellen i oppgaven er følgende:   

![Image of Table](https://github.com/kodesonen/arrangementer/blob/main/hackathon-2021/Assets/sql-table.png)