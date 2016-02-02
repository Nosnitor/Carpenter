param (
	[string]$schemaDefinition,
	[string]$xmlFile
)

Write-Output "Carpenter Source: $env:CarpenterMain"

$xmllint = "$env:CarpenterMain\Tools\Test\Dependencies\libxml2\xmllint.exe"
$cmdLine = "'$xmllint' --noout --schema $schemaDefinition $xmlFile"
Write-Output "Executing: $cmdLine"
& $xmllint --noout --schema $schemaDefinition $xmlFile; Exit $lastExitCode
