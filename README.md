# README #

Nutonomy Taxi Booking service.

### What is this repository for? ###

* Enables users to check the nearest available car and booking it for transportation.
It includes 4 projects:
* Business: Includes all the business logic
* Domain: Contains core Models and ViewModels for client interaction.
* TaxiBookingSystem_nutonomy : API server.
* Business.UnitTests : Icludes all unit Tests for testing core Business logic.

### APIs ###
* There are total 5 APIs in this exercise.
* http://localhost:8080/api/v1/book : It is a post call and gets the nearest available car.
* http://localhost:8080/api/v1/bookACar : It books a ride for a customer. 
* http://localhost:8080/api/v1/cars : To view status of all cars(booked or free) in system.
* http://localhost:8080/api/v1/tick : Increments the time stamp of service by one.
* http://localhost:8080/api/v1/reset : Resets the cars to initial position.

### How do I get set up? ###

Just clone this repository. Developed with .net core 2.0 and visual studio 2017. 

### API Documentation ###
* Swagger is integrated
* Swagger Documentation can be accessed from : http://localhost:8080/swagger/#/

### Test Server ###
* Unit Tests are developed with xUnit.
* Run test by navigating to Business.UnitTests and running command : dotnet test

### Class Diagram ###
There is an image file in repository with name NutonomyClassDiagram. This is class diagram of Nutonomy API Server. 

### Who do I talk to? ###

* Repo owner or admin
Owner : Anis ur Rehman
Contact Info : +923249020229
Email Address : anis.rehman046@gmail.com
Mobile Number : 
* Other community or team contact"# TaxiBookingIn2DGrid" 
