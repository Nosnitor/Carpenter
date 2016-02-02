@ECHO OFF

:: This script will completely refresh the environment. This will blow away local changes.

:: Verify that CarpenterMain variable exists.
IF []==[%CarpenterMain%] (
	ECHO ERROR: CarpenterMain environment variable does not exist.
	EXIT /B 1
)

:: Verify that CarpenterMain directory exists
IF NOT EXIST "%CarpenterMain%" (
	ECHO ERROR: CarpenterMain environment variable ^(%CarpenterMain%^) does not exist.
	EXIT /B 1
)

:: Clean Local Deploy
:: Local Deploy
PUSHD "%CarpenterMain%\Tools\Deploy"
CALL LocalDeploy.cmd Clean
POPD


:: Run Treeclean & Scorch
PUSHD "%CarpenterMain%"
tfpt treeclean . /Recursive /NoPrompt
tfpt scorch . /Recursive /NoPrompt
POPD

:: Build
PUSHD "%CarpenterMain%\Build"
CALL Build-Carpenter.cmd
POPD

:: Local Deploy
PUSHD "%CarpenterMain%\Tools\Deploy"
CALL LocalDeploy.cmd
POPD

:: Test
PUSHD "%CarpenterMain%\Tools\Test"
CALL ExecuteAllTests.cmd
POPD