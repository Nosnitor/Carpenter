![Carpenter](media/Carpenter-Title_400x122.png)

[Nosnitor](https://www.rcsit.com)

[![Build Status](https://dev.azure.com/nosnitor/Carpenter/_apis/build/status/Nosnitor.Carpenter?branchName=master)](https://dev.azure.com/nosnitor/Carpenter/_build/latest?definitionId=60&branchName=master)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Nosnitor_Carpenter&metric=alert_status)](https://sonarcloud.io/dashboard?id=Nosnitor_Carpenter)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=Nosnitor_Carpenter&metric=coverage)](https://sonarcloud.io/dashboard?id=Nosnitor_Carpenter)
![Deployment](https://vsrm.dev.azure.com/nosnitor/_apis/public/Release/badge/7e342f2c-9b69-45df-8ef7-b8ad9e3388c5/2/10)


# Introduction

Carpenter is a cross-platform dotnet (.NET) build process helper. Carpenter integrates into
a project to provide additional functionality as part of the build process.

## Features

Carpenter provides the following functionality:

### Developer Build Versioning

As part of the project build, consistent versioning is applied to the binaries and packages
that are created.

#### Developer Build Version

A developers build of v1.2.3, built 09/07/2019 13:34:42.346 on machine fred-pc by user fred.

Example: 1.2.3-dev.20190907-133442-346+fred-pc.fred

#### Using Developer Build Versioning

Developer build versioning is automatically applied to projects that have referenced Carpenter
and that have the value ```dev``` for the project VersionSuffix.

# Development

For details on development, please see the [Carpenter development wiki](https://dev.azure.com/nosnitor/Carpenter/_wiki/wikis/Carpenter.wiki).

Please also take note of the Carpenter [Code of Conduct](CODE_OF_CONDUCT.md) and [Contributing guidelines](CONTRIBUTING.md).