![Carpenter](media/Carpenter-Title_400x122.png)

[Nosnitor Corporation](https://www.rcsit.com)

[![Build Status](https://dev.azure.com/nosnitor/Carpenter/_apis/build/status/Nosnitor.Carpenter?branchName=master)](https://dev.azure.com/nosnitor/Carpenter/_build/latest?definitionId=60&branchName=master)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Nosnitor_Carpenter&metric=alert_status)](https://sonarcloud.io/dashboard?id=Nosnitor_Carpenter)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=Nosnitor_Carpenter&metric=coverage)](https://sonarcloud.io/dashboard?id=Nosnitor_Carpenter)


# Introduction

Carpenter is a cross-platform dotnet (.NET) build process helper. Carpenter integrates into
a project to provide additional functionality as part of the build process.

## Features

Carpenter provides the following functionality:

### Developer Build Versioning

As part of the project build, consistent versioning is applied to the binaries and packages
that are created.

| Build type | Version example | Description
|:--|:--|:--|
| Developer build | 1.2.3-dev.20190907T133442+fred-pc.fred | A developers build of v1.2.3, built 09/07/2019 13:34:42 on fred-pc by fred.

Developer build versioning is automatically applied to projects that have referenced Carpenter
and that have the value ```dev``` for the project VersionSuffix.

# Development

Commits are introduced to master branch via pull request.