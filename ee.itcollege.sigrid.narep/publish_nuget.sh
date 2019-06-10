#!/bin/sh

#clean old junk, includes custom target in Directory.Build.targets - cleans old bin and obj files
dotnet clean

# build release dll
dotnet build --configuration release 

# add .nuget files.
dotnet pack --configuration release  

#publish all the package files
nuget push -ApiKey oy2pxjcpje7sp7pdsieqkp4nivox5ebunoa7slxk62quxu -Source https://api.nuget.org/v3/index.json ee.itcollege.sigrid.narep**Release/ee.itcollege.sigrid.narep*.nupkg 
