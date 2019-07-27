# Ange

Ange is a sample application built using ASP.NET Core and Entity Framework Core and Angular.

###### Name
<div style="text-align: right"> Good names are: unique, memorable, easy to spell. </div><div style="text-align: right"> Dylan Beattie </div>   

I embraced the idea that solutions should be given a name. And you should not try to explain what it does with name, what will give you something like CompanyName Chat Message Service or even worse an acronym of it. Ange is latin name that is root for angel which cant be also translated as messenger.
Side joke about JavaScript "drinking game", googled for [Ange.js](https://www.npmjs.com/package/ange/v/1.0.1) and...

###### Structure
The architecture and design of the project is inspired by [NorthwindTraders](https://github.com/JasonGT/NorthwindTraders). Jason Taylor showed it while addressing DDD approach in following video which I heartily recommend to watch:

[Clean Architecture with ASP.NET Core 2.1](https://youtu.be/_lwCVE_XgqI) ([slide deck](https://github.com/JasonGT/NorthwindTraders/raw/master/Slides.pdf))


## Getting Started
Use these instructions to get the project up and running.

### Prerequisites
* Browser
* [.NET Core SDK 2.2](https://www.microsoft.com/net/download/dotnet-core/2.2)
* [MS SQL server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)    
  
IDE of your choice:
* [JetBrains Rider](https://www.jetbrains.com/rider/download/#section=windows) (it has 30-days trial, I encourage you to try it)
* [Visual Studio 2019](https://www.visualstudio.com/downloads/)


### Setup
Follow these steps to get your development environment set up:

  1. Clone the repository
  2. Restore required packages by running using IDE or by running:
     ```
     dotnet restore
     ```
     
  3. Change Connection string in Ange.WebUI/appsettings.json to address SQL server 
  4. Build solution using IDE or by running:
     ```
     dotnet build
     ```
  N.B.:  
   * WebUi project was created using [dotnet angular template](https://docs.microsoft.com/en-us/aspnet/core/client-side/spa/angular?view=aspnetcore-2.2&tabs=visual-studio) so just running it from IDE would start application.
   * If application is running in development environment AngeDbInitializer class would be used to populate db with some test data.
   
## Technologies
* .NET Core 2.2
* ASP.NET Core 2.2
* Entity Framework Core 2.2
* [MediatR](https://github.com/jbogard/MediatR/wiki)
Library leverages mediator pattern for solving the problem of decoupling the sending of messages from handling messages. In this solution mainly controls CQRS logic.
* [Nswager](https://github.com/RicoSuter/NSwag/wiki)  
Navigate to http://localhost:<port>/swagger to make test calls to Api

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/JasonGT/NorthwindTraders/blob/master/LICENSE.md) file for details.
