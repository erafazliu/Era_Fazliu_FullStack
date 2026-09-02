@echo off
cd /d "%~dp0..\frontend"

echo Starting Angular frontend from:
echo %CD%
echo.

if not exist "node_modules\@angular\cli" (
    echo Frontend dependencies are missing. Running npm install...
    call npm install
    if errorlevel 1 (
        echo.
        echo npm install failed. Review the error above.
        exit /b 1
    )
)

call npm start

if errorlevel 1 (
    echo.
    echo The frontend failed to start. Review the error above.
)
