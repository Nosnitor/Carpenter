@ECHO OFF

:LocateVsTest
SET VsTestConsoleExe=blah
CALL :GetPath VsTestConsoleExe "%VS140COMNTOOLS%..\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"
IF EXIST "%VsTestConsoleExe%" GOTO :FoundVsTest

CALL :GetPath VsTestConsoleExe "%VS120COMNTOOLS%..\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"
IF EXIST "%VsTestConsoleExe%" GOTO :FoundVsTest

ECHO Error: Could not locate vstest.console.exe
EXIT /B 1

:FoundVsTest

ECHO.
ECHO Executing Unit Tests...
ECHO.

"%VsTestConsoleExe%" "..\..\Source\Carpenter\Assembly.Common.Tests\bin\Debug\Assembly.Common.Tests.dll" /EnableCodeCoverage /logger:trx /InIsolation
"%VsTestConsoleExe%" "..\..\Source\Carpenter\Assembly.Common.Tests\bin\Debug\TestFiles\XmlValidation.orderedtest" /EnableCodeCoverage /logger:trx /InIsolation

GOTO:EOF

:GetPath VariableName Path
SET %~1=%~dpf2
GOTO:EOF