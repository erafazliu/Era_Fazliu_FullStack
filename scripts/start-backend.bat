@echo off
cd /d "%~dp0.."

echo Starting ASP.NET Core API from:
echo %CD%
echo.

dotnet run --project backend\PECB.SupportDesk.Api --urls http://localhost:5000

if errorlevel 1 (
    echo.
    echo The backend failed to start. Review the error above.
)
