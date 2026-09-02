@echo off
setlocal

set "PROJECT_ROOT=%~dp0"

echo Starting PECB Support Desk...
echo.

call "%PROJECT_ROOT%scripts\run-tests.bat"
if errorlevel 1 (
    echo.
    echo Tests failed. The application was not started.
    pause
    exit /b 1
)

echo.
echo All tests passed. Starting the application...
echo.

start "PECB Support Desk API" /D "%PROJECT_ROOT%scripts" cmd.exe /d /k "call start-backend.bat"

start "PECB Support Desk Frontend" /D "%PROJECT_ROOT%scripts" cmd.exe /d /k "call start-frontend.bat"

echo API:      http://localhost:5000
echo Swagger:  http://localhost:5000/swagger
echo Frontend: http://localhost:4200
echo.
echo Two terminal windows have been opened. Keep them running while using the application.
timeout /t 12 /nobreak >nul
start "" "http://localhost:4200"
start "" "http://localhost:5000/swagger"

endlocal
