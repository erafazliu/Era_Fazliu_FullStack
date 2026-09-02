@echo off
setlocal

cd /d "%~dp0.."

echo ========================================
echo Running backend tests
echo ========================================
dotnet test PecbSupportDesk.slnx --configuration Release
if errorlevel 1 (
    echo Backend tests failed.
    exit /b 1
)

echo.
echo ========================================
echo Running frontend tests
echo ========================================
cd /d "%~dp0..\frontend"

if not exist "node_modules\@angular\cli" (
    echo Frontend dependencies are missing. Running npm install...
    call npm install
    if errorlevel 1 (
        echo npm install failed.
        exit /b 1
    )
)

call npm test -- --browsers=ChromeHeadless
if errorlevel 1 (
    echo Frontend tests failed.
    exit /b 1
)

echo.
echo Backend and frontend tests passed.
exit /b 0
