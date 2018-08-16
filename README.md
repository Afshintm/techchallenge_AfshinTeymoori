# README #


### What is this repository for? ###

This is a simple .NET Core 2 web api and an angularJs front-end applications for the technical challenge I have been asked to do.



### Get up and running with Web Api app ###

To build web api just clone it and open LetsBet.Api\LetsBet.Api.sln using visual studio 2017 then Build and run it.

Webapi has got 4 projects.

1- Model Layer, 
2- Business Services Layer
3- Web APi layer
4- Unit testing -  for Business Services unit testing


### Api Endpoints: ###

Get request to show race details: http://localhost:49900/api/races/v1/details

Older version: http://localhost:49900/api/races/details

Get Customer Risk info: http://localhost:49900/api/customers/risks

Get all races: http://localhost:49900/api/races



### Get up and running with front-end App###

A simple angularJs 1.6 project to show the Races detail report

### Important ###
WebApi should be running for the following website to work.

Please run under node version 9.4.0

install npm packages and bower dependencies using following commands 

1- npm install -g grunt-cli

2- npm install

3- bower install

4- grunt serve

race details report: http://localhost:9000/#!/main


