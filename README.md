# LunasInventorySystem
System of sales and inventory

## Non-functional requirement

### Layering 
Projects defined and proposals:
* Core
	* Domain:
		* Entities
		* Constants
	* Shared: 
		* Services(Cross-cutting)
			* Unit of works (For Handle Save, And Transactions)
			* Repositories
			* Services
				* Current User
				* Current Tenant
				* Email Sending
		* Data Transfer Object
	* Application (Folder oriented to modules - Vertical Slice)
		* Products -> `CreateProduct` -> Query / Command / Event / Validator / Handler / Consumer 
			- `MediatR`, `Ardelis.Result`, `FluentValidation`
		* Extensions (`ServiceCollection`)
* Infrastructure
	* Persistence
		* Configurations (`EntityTypeConfiguration`)
		* Constants
		* Contexts (Multi-Tenant) - `Microsoft.EntityFrameworkCore.SqlServer`
		* Extensions (`ServiceCollection`, `Querayble`)
		* Interceptors (Auditing)
		* Migrations - `Microsoft.EntityFrameworkCore.Tools`
		* Repositories (Raw SQL Queries)
		* Specifications - `Ardalis.Specification.EntityFrameworkCore`
	* Infrastructure:
		* Jobs `Hangfire`
			* Outbox
		* Emails
* Distribution (Output)
	* Server
		* `Serilog (AspNetCore, Exceptions.EntityFrameworkCore (UseExceptionProcessor()))`
		* Swagger
		* Middleware (Error Handling)
		* Endpoints -> Endpoint Handler - `Ardalis.ApiEndpoints`
		* Actuators -> [Exploring all actuators | Steeltoe](https://docs.steeltoe.io/guides/get-to-know-steeltoe/exercise2.html?tabs=visual-studio)
		* Configurations
	* Server Contracts
		* Request / Response / Endpoint
	* Client
		* View Models
		* Client Service
* Tests
	* Architecture
	* Application
		* Products -> `CreateProduct` -> Query / Command / Event / Validator / Handler / Consumer
	* Integration
	* Unit Tests
* Migrator - `Spectre.Console`
	* Run migrations
	* Created database
	

### Project
* Editor config
* Static Code Analyzer
* Docker
* Docker compose
* Tracing `Serilog` + `Sequalizer`
* Multi tenant `Finbuckle.MultiTenant`
* Health Checks

## Stage 1 - User cases
- [ ] Control Access
- [ ] License Management
- [ ] Scenarios - Login Type Access
	- [ ] Cashier
	- [ ] Inventory
	- [ ] Sales
	- [ ] Auditing
	- [ ] Administrator
		- [ ] Products List
		- [ ] Customer List
		- [ ] Sales
			- [ ] Register Quote
			- [ ] Register Sale
		- [ ] Sales List
		- [ ] NCF List
		- [ ] Users List
		- [ ] Employees List
		- [ ] Turn List
		- [ ] Change user
