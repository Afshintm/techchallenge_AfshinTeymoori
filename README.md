# README #


### What is this repository for? ###

This is a simple .NET Core 2 web api and an angularJs front-end applications for the technical challenge I have been asked to do.



### Ge up and running with Web Api app ###

Webapi has got 4 projects. Autofac is Dependency Injection used. 

1- Model Layer, 
2- Business Services Layer
3- Web APi layer
4- Unit testing -  for Business Services unit testing

To get the web api application up and running just clone it and open Backend.sln using visual studio 2017 then Build and run it.

##Api Endpoint:##
Get request to show race details: http://localhost:49900/api/races/v1/details

Older version: http://localhost:49900/api/races/details

Get Customer Risk info: http://localhost:49900/api/customers/risks

Get all races: http://localhost:49900/api/races



### Ge up and running with front-end ###
A simple angularJs 1.6 project to show the Races detail report

Please run under node version 9.4.0
install npm packages and bower dependencies using following commands 

1- npm install -g grunt-cli

2- npm install

3- bower install

4- grunt serve

race details report: http://localhost:9000/#!/main


