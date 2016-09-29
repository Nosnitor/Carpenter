# Carpenter - A TFS build system helper #

The Carpenter project contains Visual Studio and Team Foundation Server focused build scripts and functionality used by Nosnitor applications.

* [Features](#features)
    - [Code Analysis Custom Dictionary](#code-analysis-custom-dictionary)
    - [Product Versioning](#product-versioning)
        * [Versioning Definitions](#versioning-definitions)
        * [Release Version](#release-version)
        * [Build Version](#build-version)
        * [Associated Scripts](#associated-scripts)
    - [Show Build Properties](#show-build-properties)
* [Required Environment Variables](#required-environment-variables)

## Features ##

### Code Analysis Custom Dictionary ###

Provides a template custom dictionary to be used to modify the dictionary used by code analysis during the project build.
A schema is also provided in the package and available on the web through:  http://schemas.nosnitor.com/2014/07/Dictionary

### Product Versioning ###

Carpenter provides uniform product versioning for your project. Versioning conforms to SemVer 2.0 specification.

#### Versioning Definitions ####

| Term			| Definition																						|
|:---			|:---																								|
| Major Version | Defined by SemVer 2.0: MAJOR version when you make incompatible API changes.						|
| Minor Version | Defined by SemVer 2.0: MINOR version when you add functionality in a backwards-compatable manner. |
| Patch Version | Defined by SemVer 2.0: PATCH version when you make backwards-compatable bug fixes.				|
| Version Label | The version label is used to identify pre-release, BVT, CI, developer or custom builds.			|
| Changeset		| The TFS changeset associated with the build.														|

#### Release Version ####

The release version is the <Major>.<Minor>.<Patch> version of the software. This is mostly used for product marketing
(sometimes abbreviated as v<Major> or even Version <Major>).

For example, a manual may define the software version for WidgetsApp as WidgetsApp v2.3.2 - though this may be too
specific and really should only be used in cases where documentation is changed on a patch release. Product
documentation can also refer to this version as WidgetsApp v2.3 especially in cases where the documentation does
not change on a patch release. WidgetsApp v2 or WidgetsApp 2 may also be used.

#### Build Version ####

The build version defines the version of the build. This nomenclature identifies the exact information necessary
to determine when the assemblies were built from source code. Each build process will generate a build identifier.
This version uses SemVer v2.0 (http://semver.org).

This build is used for release filenames, build-specific or automated documentation, etc. Local builds are defined as
developer builds, CI builds are defined as CI builds.

Carpenter-<Major>.<Minor>.<Patch><Label>

| Build Version										| Description							|
|:---												|:---									|
| Carpenter-1.0.0									| v1.0.0 release						|
| Carpenter-2.6.14-dev.12678+frankc.20150901.190007	| v2.6.14 Developer Build - Built by user frankc on 9/1/2015 at 7:00pm (and 7 seconds) using changeset 12678 (modifications may be present in the changeset, it is almost expected they will be). By nature, these types of builds should only be used to debug specific issues, test specific fixes, etc. No issues should be reported on Dev builds, because they are generated in an unmanaged environment and can not be linked to a specific source code.	|
| Carpenter-1.0.4-CI.20150829.11					| v1.0.4 Continuous Integration build - Ran on 8/29/2015, the 11th build that day.	|
| Carpenter-2.5.3-alpha.11							| v2.5.3 alpha build 1
| Carpenter-2.5.3-beta.4							| v2.5.3 beta build 4
| Carpenter-4.3.1-rc.11								| v4.3.1 Release Candidate 1

The ProductVersion attribute of .NET assemblies are to be populated with this value.

#### Associated Scripts ####

* New-SetDeveloperBuildVariablesScript.ps1 - Used to generate and apply versioning information in a developer environment.
* Set-AssemblyInfoTfsRevision.ps1 - Used to modify values in AssemblyInfo templates.

### Show Build Properties ###

Carpenter.psm1 provides Show-BuildProperties cmdlet that will display all TFS and Carpenter build environment variables.
This can be used as part of a pre-build event to write this information to build logs for troubleshooting and
diagnostic purposes.

#### Example ####
```
:: %1 - $(SolutionDir)
@ECHO OFF

:: Display Build properties
PowerShell -Command "If (-Not (Get-Module -Name Carpenter)) { Import-Module '%~1Carpenter.Common\Scripts\Carpenter.psd1' }; Show-BuildProperties"
IF %ErrorLevel% NEQ 0 EXIT /B %ErrorLevel%
```
An example is also included in Carpenter-PreBuild-Example.cmd.

#### Outputs ####
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

## Required Environment Variables ##

BUILD_SOURCESDIRECTORY
* Used by PesterTest XML output, will throw a warning during build if it does not exist
* Used by PesterTest to set path for TF changeset - this path should be set to working directory e.g. C:\Dev\Carpenter\Main
