@ECHO OFF
SETLOCAL

:LocateMsBuild
ECHO Looking for MSBuild.exe

:: Look for VS2015 MSBuild
SET MSBuildExe="%ProgramFiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe"
IF EXIST %MSBuildExe% GOTO :FoundMsBuild

:: Look for VS2013 MSBuild
SET MSBuildExe="%ProgramFiles(x86)%\MSBuild\12.0\Bin\MSBuild.exe"
IF EXIST %MSBuildExe% GOTO :FoundMsBuild

ECHO Error: Could not locate MSBuild.exe
EXIT /B 1

:FoundMsBuild
ECHO Building solution...

:: Reset Code Analysis Rules
PUSHD ..
DEL "*.lastcodeanalysissucceeded" /F /S /Q
POPD

:: Build Solution
SET CmdLine=%MSBuildExe% ..\Source\Carpenter\Carpenter.sln /m /p:RunCodeAnalysis=true /t:Clean,Build
ECHO Executing: %CmdLine%
%CmdLine%


ENDLOCAL