@echo off

set folderNugets=C:\LocalPackages

del %folderNugets%\Marquitos.AspNetCore.*

dotnet pack -c Release .\..\src\Marquitos.AspNetCore.Components --include-symbols --output %folderNugets%

pause