#!/bin/bash

set -u

PROJECT_ROOT="$(cd "$(dirname "$0")" && pwd)"
FRONTEND_DIR="$PROJECT_ROOT/frontend"
BACKEND_PROJECT="$PROJECT_ROOT/backend/PECB.SupportDesk.Api"

cleanup() {
  echo
  echo "Stopping PECB Support Desk..."
  [[ -n "${FRONTEND_PID:-}" ]] && kill "$FRONTEND_PID" 2>/dev/null || true
  [[ -n "${BACKEND_PID:-}" ]] && kill "$BACKEND_PID" 2>/dev/null || true
}

trap cleanup EXIT INT TERM

if ! command -v dotnet >/dev/null 2>&1; then
  echo "Error: .NET SDK is not installed or is not available on PATH."
  exit 1
fi

if ! command -v npm >/dev/null 2>&1; then
  echo "Error: Node.js and npm are not installed or are not available on PATH."
  exit 1
fi

echo "Starting PECB Support Desk..."
echo

if [[ ! -d "$FRONTEND_DIR/node_modules/@angular/cli" ]]; then
  echo "Installing frontend dependencies..."
  (cd "$FRONTEND_DIR" && npm install) || {
    echo "Error: npm install failed."
    exit 1
  }
fi

echo
echo "========================================"
echo "Running backend tests"
echo "========================================"
dotnet test "$PROJECT_ROOT/PecbSupportDesk.slnx" --configuration Release || {
  echo "Error: backend tests failed. The application was not started."
  exit 1
}

echo
echo "========================================"
echo "Running frontend tests"
echo "========================================"
(cd "$FRONTEND_DIR" && npm test -- --browsers=ChromeHeadless) || {
  echo "Error: frontend tests failed. The application was not started."
  exit 1
}

echo
echo "All tests passed. Starting the application..."
echo

echo "Starting ASP.NET Core API on http://localhost:5000..."
dotnet run --project "$BACKEND_PROJECT" --urls http://localhost:5000 &
BACKEND_PID=$!

echo "Starting Angular frontend on http://localhost:4200..."
(cd "$FRONTEND_DIR" && npm start) &
FRONTEND_PID=$!

sleep 12

if ! kill -0 "$BACKEND_PID" 2>/dev/null; then
  echo "Error: the backend stopped during startup. Check the output above."
  exit 1
fi

if ! kill -0 "$FRONTEND_PID" 2>/dev/null; then
  echo "Error: the frontend stopped during startup. Check the output above."
  exit 1
fi

open "http://localhost:4200"
open "http://localhost:5000/swagger"

echo
echo "PECB Support Desk is running."
echo "Frontend: http://localhost:4200"
echo "Swagger:  http://localhost:5000/swagger"
echo "Press Control-C to stop both services."
echo

wait "$BACKEND_PID" "$FRONTEND_PID"
