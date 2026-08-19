# Becher Andoura Website

Personal portfolio and service website for Becher Andoura, built with Angular 22 and .NET 10.

## Structure

- `src/BecherAndoura.Api` - ASP.NET Core Minimal API and endpoint composition.
- `src/BecherAndoura.Application` - use cases, validation, and abstractions.
- `src/BecherAndoura.Domain` - portfolio and contact domain models.
- `src/BecherAndoura.Infrastructure` - in-memory content and contact repositories.
- `client` - Angular standalone single-page app.

## Run Locally

Start the backend:

```powershell
dotnet run --project .\src\BecherAndoura.Api\BecherAndoura.Api.csproj --launch-profile http
```

Install and start the frontend:

```powershell
cd .\client
pnpm install
pnpm start
```

Open `http://localhost:4300`. The Angular dev proxy forwards `/api` requests to `http://localhost:5004`.

## Notes

- The backend uses Clean Architecture style boundaries, dependency inversion, repository abstractions, validation services, and Minimal API endpoint groups.
- The frontend uses standalone Angular components, signals, reactive forms, strict TypeScript, responsive SCSS, and API fallback content.
