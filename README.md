# Carpenter - A TFS build system helper #

The Carpenter project contains Visual Studio and Team Foundation Server focused build scripts and functionality used by Nosnitor applications.

* [Carpenter Variables](#carpenter-variables)
* [Features](#features)
    - [Code Analysis Custom Dictionary](#code-analysis-custom-dictionary)
    - [Product Versioning](#product-versioning)
        * [Versioning Definitions](#versioning-definitions)
        * [Release Version](#release-version)
        * [Build Version](#build-version)
        * [Associated Scripts](#associated-scripts)
    - [Show Build Properties](#show-build-properties)
* [Required Environment Variables](#required-environment-variables)

## Carpenter Variables ##

Carpenter adds to existing TFS build & release variables to accomodate additional functionality.

| Variable Name          | Environment Variable Name        | Description                                           |
|:---                    |:---                              |:---                                                   |
| VersionMajor           | VersionMajor                     | The Major version used for build scripts and operations. |
| VersionMinor           | VersionMinor                     | The Minor version used for build scripts and operations. |
| VersionPatch           | VersionPatch                     | The Patch version used for build scripts and operations. |
| VersionLabel           | VersionLabel                     | The label for the version used for build scripts and operations. |
| BuildVersion 			 | BuildVersion 					||
| BuildNotes 			 | BuildNotes 						||
| NuGetPackageVersion    | NuGetPackageVersion              | The version string that is used for NuGet packages. |


## Features ##

### Code Analysis Custom Dictionary ###

Provides a template custom dictionary to be used to modify the dictionary used by code analysis during the project build.
A schema is also provided in the package and available on the web through:  http://schemas.nosnitor.com/2014/07/Dictionary

A file located at XML\CustomDictionary.xml will be added to your project. 

To start using the custom dictionary:

1. Select the CustomDictionary.xml file in the Solution Explorer.
2. In the Properties window, change Build Action to CodeAnalysisDictionary.

To share your custom dictionary with other projects in your solution:

1. Add a link in your other project to the CustomDictionary in the project Carpenter is installed in.
(see https://msdn.microsoft.com/en-us/library/windows/apps/jj714082(v=vs.105).aspx)
2. Select the linked version of the CustomDictionary.xml file in the Solution Explorer.
3. In the Properties window, change Build Action to CodeAnalysisDictionary. 

More information: https://msdn.microsoft.com/en-us/library/bb514188.aspx

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

#### Assembly Version ####

The AssemblyVersion attribute and AssemblyFileVersion attribute use the following definition:

<Major>.<Minor>.<Patch>.<Changeset>
    
This nomenclature is used regardless of the environment that the file is built in. 

#### Release Version ####

The release version is the <Major>.<Minor>.<Patch> version of the software. This is mostly used for product marketing
(sometimes abbreviated as v<Major> or even Version <Major>).

For example, a manual may define the software version for WidgetsApp as WidgetsApp v2.3.2 - though this may be too
specific and really should only be used in cases where documentation is changed on a patch release. Product
documentation can also refer to this version as WidgetsApp v2.3 especially in cases where the documentation does
not change on a patch release. WidgetsApp v2 or WidgetsApp 2 may also be used.

#### Build Version ####

The build version defines the version of the build. This nomenclature identifies the exact information necessary
to determin when the assemblies were built from source code. Each build process will generate a build identifier.
This version uses SemVer v2.0 (http://semver.org).

This build is used for release filenames, build-specific or automated documentation, etc. Local builds are defined as
developer builds, CI builds are defined as CI builds.

Carpenter-<Major>.<Minor>.<Patch><Label>

| Build Version										| Description							|
|:---												|:---									|
| Carpenter-1.0.0									| v1.0.0 release						|
| Carpenter-2.6.14-dev.12678+frankc.20150901.190007	| v2.6.14 Developer Build - Built by user frankc on 9/1/2015 at 7:00pm (and 7 seconds) using changeset 12678 (modifications may be present in the changeset, it is almost expected they will be). By nature, these types of builds should only be used to debug specific issues, test specific fixes, etc. No issues should be reported on Dev builds, because they are generated in an unmanaged environment and can not be linked to a specific source code.	|
| Carpenter-1.0.4-CI.20150829.11					| v1.0.4 Continuous Integration build - Ran on 8/29/2015, the 11th build that day.	|
| Carpenter-2.5.3-alpha.2							| v2.5.3 alpha build 2
| Carpenter-2.5.3-beta.4							| v2.5.3 beta build 4
| Carpenter-4.3.1-rc.1								| v4.3.1 Release Candidate 1

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
:: Display Build properties
PowerShell -Command "If (-Not (Get-Module -Name Carpenter)) { Import-Module 'Carpenter.psd1' }; Show-BuildProperties"
IF %ErrorLevel% NEQ 0 EXIT /B %ErrorLevel%
```
An example is also included in Carpenter-PreBuild-Example.cmd.

#### Outputs ####
```
         System.CollectionId                : 0c4d078c-9ab2-40cd-b54b-f8e44642cf67
         System.DefaultWorkingDirectory     : C:\Bin\vsoagent\_work\6\s
         System.DefinitionId                : 1
         System.TeamFoundationServerUri     : http://tfs.xxxxxxxx.com:8080/tfs/RD/
         System.TeamFoundationCollectionUri : http://tfs.xxxxxxxx.com:8080/tfs/RD/
         System.TeamProject                 : Carpenter
         System.TeamProjectId               : ffffffff-ffff-ffff-ffff-ffffffffff
         Build.DefinitionName               : BvtCarpenterMain
         Build.DefinitionVersion            : 35
         Build.BuildNumber                  : Carpenter-0.1.0-BVT.20160511.1
         Build.BuildUri                     : vstfs:///Build/Build/404
         Build.BuildId                      : 404
         Build.QueuedBy                     : Jeff Block
         Build.QueuedById                   : ffffffff-ffff-ffff-ffff-ffffffffff
         Build.RequestedFor                 : Jeff Block
         Build.RequestedForId               : ffffffff-ffff-ffff-ffff-ffffffffff
         Build.SourceVersion                : C203
         Build.SourceBranch                 : $/Carpenter/Main
         Build.SourceBranchName             : Main
         Build.Repository.Name              : Carpenter
         Build.Repository.Provider          : TfsVersionControl
         Build.Repository.Clean             : True
         Build.Repository.Uri               : http://tfs.xxxxxxxx.com:8080/tfs/RD/
         Build.Repository.Tfvc.Workspace    : ws_6_3
         Agent.Name                         : Agent-BUILD1
         Agent.Id                           : 3
         Agent.HomeDirectory                : C:\Bin\vsoagent
         Agent.RootDirectory                : C:\Bin\vsoagent\_work
         Agent.WorkFolder                   : C:\Bin\vsoagent\_work
         Common.TestResultsDirectory        : C:\Bin\vsoagent\_work\6\TestResults
         Build.Repository.LocalPath         : C:\Bin\vsoagent\_work\6\s
         Build.SourcesDirectory             : C:\Bin\vsoagent\_work\6\s
         Build.BinariesDirectory            : C:\Bin\vsoagent\_work\6\b
         Build.ArtifactStagingDirectory     : C:\Bin\vsoagent\_work\6\a
         Build.StagingDirectory             : C:\Bin\vsoagent\_work\6\a
         Agent.BuildDirectory               : C:\Bin\vsoagent\_work\6
         Agent.JobName                      : Build
         Agent.MachineName                  : BUILD1
         Agent.WorkingDirectory             : C:\Bin\vsoagent\_work\SourceRootMapping\ff
                                              ffffff-ffff-ffff-ffff-ffffffffff0c\Job-fff
                                              fffff-ffff-ffff-ffff-ffffffffff
         VersionMajor                       : 0
         VersionMinor                       : 1
         VersionPatch                       : 0
         VersionLabel                       : -BVT
         BuildVersion                       : 0.1.0-BVT.20160511.1 
         NuGetPackageVersion                : 0.1.0-BVT201605111
```

## Required Environment Variables ##

BUILD_SOURCESDIRECTORY
* Used by PesterTest XML output, will throw a warning during build if it does not exist
* Used by PesterTest to set path for TF changeset - this path should be set to working directory e.g. C:\Dev\Carpenter\Main
