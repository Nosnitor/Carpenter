@ECHO OFF
ECHO Deploying Carpenter locally...

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

IF /I [%~1] == [Clean] GOTO :Clean

IF NOT EXIST "C:\Bin" (MD C:\Bin)
IF NOT EXIST "C:\Bin\Carpenter" ( MD C:\Bin\Carpenter )
XCOPY "%CarpenterMain%\Documentation\Readme.txt" "C:\Bin\Carpenter\" /Y /F /V /I
IF NOT EXIST "C:\Bin\Carpenter\XML" ( MD C:\Bin\Carpenter\XML )
XCOPY "%CarpenterMain%\Source\Carpenter\Assembly.Common\XML\*.*" "C:\Bin\Carpenter\XML\" /Y /F /V /I
GOTO:EOF

:Clean
ECHO Cleaning Carpenter...
IF EXIST "C:\Bin\Carpenter" ( RD C:\Bin\Carpenter /S /Q )
GOTO:EOF

:Usage
ECHO %App% action
ECHO Actions: clean
GOTO:EOF