# Carpenter - Common Build System

The Carpenter project contains Visual Studio and Team Foundation Server focused build scripts and functionality used by Nosnitor applications.

* [Functionality](#the-scripts)

## Documentation

A Readme.txt file is distributed with the project.

## Features

* Common Dictionary

## The Scripts

### ListBuildProperties.ps1
This script will list all TFS and NosBuild environment variables so that they can be included with build logs.

####Usage
.\ListBuildProperties.ps1

####Outputs
```
2015-11-19T22:16:14.6844083Z System.TeamProject                 : NosBuild
2015-11-19T22:16:14.6844083Z System.TeamFoundationCollectionUri : https://xxxxxxx.visualstudio.com/DefaultC
2015-11-19T22:16:14.6844083Z                                      ollection/
2015-11-19T22:16:14.6844083Z System.CollectionId                : ffffffff-ffff-ffff-ffff-ffffffffffff
2015-11-19T22:16:14.6844083Z System.DefaultWorkingDirectory     : C:\bin\BuildAgent\_work\ffffffff\NosBuild
2015-11-19T22:16:14.6844083Z Build.DefinitionName               : NosBuild-CI
2015-11-19T22:16:14.6844083Z Build.DefinitionVersion            : 65
2015-11-19T22:16:14.6844083Z Build.BuildNumber                  : NosBuild-1.0.1-CI.20151119.12
2015-11-19T22:16:14.6844083Z Build.BuildUri                     : vstfs:///Build/Build/529
2015-11-19T22:16:14.6844083Z Build.BuildId                      : 529
2015-11-19T22:16:14.7000086Z Build.QueuedBy                     : [DefaultCollection]\Project Collection 
2015-11-19T22:16:14.7000086Z                                      Service Accounts
2015-11-19T22:16:14.7000086Z Build.QueuedById                   : ffffffff-ffff-ffff-ffff-ffffffffffff
2015-11-19T22:16:14.7000086Z Build.RequestedFor                 : Jeff Block
2015-11-19T22:16:14.7000086Z Build.RequestedForId               : ffffffff-ffff-ffff-ffff-ffffffffffff
2015-11-19T22:16:14.7000086Z Build.SourceVersion                : C851
2015-11-19T22:16:14.7000086Z Build.SourceBranch                 : $/NosBuild/Main
2015-11-19T22:16:14.7000086Z Build.SourceBranchName             : Main
2015-11-19T22:16:14.7000086Z Build.Repository.Name              : NosBuild
2015-11-19T22:16:14.7000086Z Build.Repository.Provider          : TfsVersionControl
2015-11-19T22:16:14.7000086Z Build.Repository.Clean             : True
2015-11-19T22:16:14.7000086Z Build.Repository.Uri               : https://xxxxxxx.visualstudio.com/DefaultC
2015-11-19T22:16:14.7000086Z                                      ollection/
2015-11-19T22:16:14.7000086Z Build.Repository.Tfvc.Workspace    : ws_ffffffff_5
2015-11-19T22:16:14.7000086Z Agent.Name                         : Agent-SA01-BUILD0001
2015-11-19T22:16:14.7000086Z Agent.Id                           : 5
2015-11-19T22:16:14.7000086Z Agent.HomeDirectory                : C:\bin\BuildAgent
2015-11-19T22:16:14.7000086Z Agent.RootDirectory                : C:\bin\BuildAgent\_work
2015-11-19T22:16:14.7156089Z Agent.WorkFolder                   : C:\bin\BuildAgent\_work
2015-11-19T22:16:14.7156089Z Build.Repository.LocalPath         : C:\bin\BuildAgent\_work\ffffffff\NosBuild
2015-11-19T22:16:14.7156089Z Build.SourcesDirectory             : C:\bin\BuildAgent\_work\ffffffff\NosBuild
2015-11-19T22:16:14.7156089Z Build.ArtifactStagingDirectory     : C:\bin\BuildAgent\_work\ffffffff\a
2015-11-19T22:16:14.7156089Z Build.StagingDirectory             : C:\bin\BuildAgent\_work\ffffffff\a
2015-11-19T22:16:14.7156089Z Agent.BuildDirectory               : C:\bin\BuildAgent\_work\ffffffff
2015-11-19T22:16:14.7156089Z VersionMajor                       : 1
2015-11-19T22:16:14.7156089Z VersionMinor                       : 0
2015-11-19T22:16:14.7156089Z VersionPatch                       : 1
2015-11-19T22:16:14.7156089Z VersionLabel                       : -CI.20151119.12 
2015-11-19T22:16:14.7156089Z BuildVersion                       : 1.0.1-CI.20151119.12 
2015-11-19T22:16:14.7156089Z BuildNotes                         : Continuous Integration Build
```