# RuletaRusa

Base from Domain-Driven Design
https://es.wikipedia.org/wiki/Dise%C3%B1o_guiado_por_el_dominio


Structure 

1.Presentation
--Api
---RussianRoulette.Api 
-----Using (Net Core 3.1 + Swagger)
2.Application
--Definition
--Implementation
--Test 
3.Core
--Dtos
--Entities
--Repository
4.Data
--Common
--Providers
----RedisLabs (https://app.redislabs.com/)
----StackExchange.Redis (https://stackexchange.github.io/StackExchange.Redis/)
5.Crosscutting
6.Testing
7.IoC

Used patterns

Repository
Facade
Dependency injection