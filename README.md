# PECB Support Desk

A professional internal support workflow application built with ASP.NET Core, Entity Framework Core, Angular, and SQL Server. The visual system uses the PECB logo red (`#ad1927`) with neutral business surfaces and accessible status cues.

## Run locally

Prerequisites: .NET 10 SDK, Node.js 20+, and SQL Server LocalDB (Windows) or Docker.

### Quick start on Windows

Double-click `start-support-desk.bat` in the project folder. It first runs the backend and frontend test suites. If they pass, it opens separate backend and frontend terminal windows, then opens the application and Swagger UI in your browser. To run only the tests, double-click `scripts\run-tests.bat`.

### Quick start on macOS

SQL Server LocalDB is Windows-only. Start the Docker database with `docker compose up -d`, then configure `ConnectionStrings:SupportDesk` as described below.

On first use, make the launcher executable and run it:

```bash
chmod +x start-support-desk-macos.command
./start-support-desk-macos.command
```

You can subsequently double-click `start-support-desk-macos.command` in Finder. It runs both test suites first. If they pass, it starts both services, opens the frontend and Swagger, and stops both when you press Control-C.

## Launcher and test scripts

| Script | Platform | Purpose |
| --- | --- | --- |
| `start-support-desk.bat` | Windows | Main launcher. Runs all tests, starts the backend and frontend in separate terminal windows, and opens the application and Swagger. |
| `scripts\run-tests.bat` | Windows | Runs the 9 backend tests and 2 Angular tests without starting the application. It returns a failure exit code if either suite fails. |
| `scripts\start-backend.bat` | Windows | Starts only the ASP.NET Core API on port 5000. It is used internally by the main Windows launcher. |
| `scripts\start-frontend.bat` | Windows | Installs npm packages when missing and starts only Angular on port 4200. It is used internally by the main Windows launcher. |
| `start-support-desk-macos.command` | macOS | Main macOS launcher. Installs npm packages when missing, runs all tests, starts both services, opens the application and Swagger, and stops both services with Control-C. |

The `.bat` files are Windows Command Prompt scripts. The `.command` file is a macOS shell script that can be launched from Terminal or Finder after `chmod +x start-support-desk-macos.command`.

## Why `docker-compose.yml` is included

The application requires SQL Server. Windows users can use SQL Server LocalDB through the default connection string, but LocalDB is not available on macOS or Linux. `docker-compose.yml` provides a consistent SQL Server 2022 container for those systems and is also useful when a Windows developer does not have LocalDB installed.

Start the container with:

```bash
docker compose up -d
```

When using Docker, configure the API connection string as:

```text
Server=localhost,1433;Database=PecbSupportDesk;User Id=sa;Password=PecbDesk!2026Strong;TrustServerCertificate=True
```

The Docker volume `supportdesk-data` keeps the database between container restarts. Stop the container with `docker compose stop`; `docker compose down` removes the container but retains the named volume unless `--volumes` is explicitly supplied.

1. Database: the default connection in `backend/PECB.SupportDesk.Api/appsettings.json` uses `(localdb)\\MSSQLLocalDB`. For Docker, run `docker compose up -d` and change `ConnectionStrings:SupportDesk` to `Server=localhost,1433;Database=PecbSupportDesk;User Id=sa;Password=PecbDesk!2026Strong;TrustServerCertificate=True`.
2. Backend: `dotnet restore`, then `dotnet run --project backend/PECB.SupportDesk.Api --urls http://localhost:5000`. Migrations apply automatically and insert 5 agents plus 40 tickets.
3. Frontend: `cd frontend`, `npm install`, then `npm start`. Open `http://localhost:4200`.
4. Tests: run `dotnet test` at the repository root and `npm test` inside `frontend`.

Swagger API documentation is available in development at `http://localhost:5000/swagger`.

## Design and business rules

Workflow rules live in `TicketWorkflowService`; controllers orchestrate persistence and HTTP responses while EF entities remain internal. A dedicated `PUT /api/tickets/{id}/status` endpoint expresses workflow intent, prevents generic updates from changing system-owned dates, and returns machine-readable `ProblemDetails` on rejection.

Due dates use the original creation timestamp (Critical 4 hours, High 1 day, Normal 3 days, Low 7 days) and are recalculated when priority changes. Status transitions are strictly New → In Progress → Resolved → Closed, plus Resolved → In Progress. Starting work requires an active agent. Closed tickets reject edits, assignments, status changes, comments, and deletion. Resolved and closed dates are set only by the server. Overdue means past due and neither Resolved nor Closed.

The Angular client uses standalone components, reactive forms, service-isolated HTTP calls, debounced search, server-side filters, sortable table headers, 10/50/200-row pagination, loading/empty states, readable API errors, and delete confirmation.

## Assumptions

- Timestamps are UTC `DateTimeOffset` values.
- Reopening clears the resolved date so it represents the latest resolution cycle.
- References use the year and next database identity; production would use a database sequence for concurrency.
- Deleting a non-closed ticket is allowed; closed tickets are immutable audit records.
- Authentication is outside the assignment, so comment author is entered explicitly.

## With more time

Authentication and roles, optimistic concurrency, audit history, notifications, SLA escalation, richer integration tests, sorting, accessible toast notifications, observability, and production-grade reference generation.

Implementation time: approximately 8 hours for a production-polished take-home assignment.
