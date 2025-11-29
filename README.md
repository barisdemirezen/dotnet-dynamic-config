# Dotnet Dynamic Config 🎉

Dotnet Dynamic Config is a handy project that helps to create dynamic configuration in .net core projects.

## About it 📝

Dotnet Dynamic Config allows developers to make configuration changes without re-deploying or restarting running .net core projects.

It uses Sql Server as persistent store and Redis pub/sub to communicate with consumer projects.

**Publisher Project** shows existing keys/values and can modify existing values
**Subscriber Project** shows a demo endpoint to check if system works.

## Install, run, dev 🏗️

First you have to build your database and table. Run the PreRequisites/Database.sql file on your Sql Server.

Make sure you have a Redis running.

## Tech Stack 🔥

**Languages:** .NET 6

**Client:** .NET 6 MVC with Bootstrap

**Server:** .NET 6 WEBAPI

**Data Store:** Sql Server, Redis

## Badges 📌

[![img](https://img.shields.io/github/last-commit/barisdemirezen/dotnet-dynamic-config/main?style=flat-square)](https://img.shields.io/github/last-commit/barisdemirezen/dotnet-dynamic-config/main?style=flat-square)
