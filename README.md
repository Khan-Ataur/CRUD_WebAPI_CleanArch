<h2>.NET Core 8.0 - CRUD - Web API  Clean Architecture using Repository Pattern and Dapper.</h2>

<h3>I have used following tools, technologies, and framework in this project:</h3>

<li>Visual Studio 2022 and .NET Core 8.0</li>
<li>C#</li>
<li>MS SQL DB</li>
<li>Clean Architecture :</li> The Clean Architecture is the system architecture guideline proposed by Robert C. Martin also known as Uncle Bob. It derived from many architectural guidelines such as Hexagonal Architecture, Onion Architecture, etc.
<li>Dapper (mini ORM)</li> Dapper is a simple Object Mapper or a Micro-ORM and is responsible for mapping between database and programming language.
<li>Repository Pattern</li>
<li>Unit of Work</li>
<li>Swagger UI</li>
<li>API Authentication (Key Based)</li>

<h3>Solution and Project setup:</h3>

<p><span style="font-size:20px"><strong>******<a href="https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html">According to Clean Architecture</a>*******</strong></span></p>

<p><span style="font-size:16px"><strong>a) Core Layer:</strong> Core Layer is independent i.e core layer does not depend on any other layer.</span></p>

<p><span style="font-size:16px"><strong>b) Appliction Layer:</strong> Application layer depends on Core layer. To do this, add referance of core layer into Application layer.</span></p>

<p><span style="font-size:16px">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</span>- Add folder named Interfaces</p>

<p><span style="font-size:16px"><strong>c) Logging Layer: </strong>Logging layer depends on Application layer. To do this, add referance of Application layer into Logging layer.</span></p>

<p><span style="font-size:16px">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</span><span style="font-size:16px">And add log4net nuget package in this layer.</span></p>

<p><span style="font-size:16px"><strong>d) Infrastructure Layer:&nbsp;</strong>Infrastructure layer depends on both Application and Core layer. To do this, add referance of both layer into infrastructure layer.</span></p>

<p><span style="font-size:16px">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</span> - Add folder named Repository&nbsp;</p>

<p><span style="font-size:16px">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</span> &nbsp;- Add folder named Dapper</p>

<p><span style="font-size:16px">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</span>&nbsp; - Install nuget package : Dapper</p>

<p><span style="font-size:16px">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</span>&nbsp; - Install nuget package : Microsoft.Extensions.Configuration</p>

<p><span style="font-size:16px">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</span>&nbsp; -&nbsp;Install nuget package : Microsoft.Extensions.DependencyInjection.Abstractions</p>

<p><span style="font-size:16px">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</span>&nbsp; -&nbsp;Install nuget package : System.Data.SqlClient</p>

<p><span style="font-size:16px"><strong>e) Presentation Layer: </strong>In this layer I have used ASP.NET Core Web API project. Presentation layer depends on all layer. To do this, add referance of Application,Core, Infrustructure and Logging layer&nbsp; into this layer.</span></p>

<p>&nbsp;</p>


