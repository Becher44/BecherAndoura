# Becher Andoura Website

Customer-friendly portfolio and service request website for Becher Andoura, built with Angular 22 and .NET 10.

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

## Contact Email

All service requests are addressed to `Becherandoura@hotmail.com` and sent through the Gmail sender account `Becherandoura@gmail.com`.

Set SMTP values in the hosting environment to send form submissions as email:

```powershell
$env:ContactEmail__SenderEmail = "Becherandoura@gmail.com"
$env:ContactEmail__Smtp__Host = "smtp.gmail.com"
$env:ContactEmail__Smtp__Port = "587"
$env:ContactEmail__Smtp__EnableSsl = "true"
$env:ContactEmail__Smtp__UserName = "Becherandoura@gmail.com"
$env:ContactEmail__Smtp__Password = "your-gmail-app-password"
```

For local development, store the Gmail app password with .NET user secrets instead of `appsettings.json`:

```powershell
dotnet user-secrets set "ContactEmail:Smtp:Password" "your-gmail-app-password" --project .\src\BecherAndoura.Api\BecherAndoura.Api.csproj
```

Email passwords and app passwords should stay in environment variables, .NET user secrets, or host secrets, not in git.

## Notes

- The backend uses Clean Architecture style boundaries, dependency inversion, repository abstractions, validation services, and Minimal API endpoint groups.
- The frontend uses standalone Angular components, signals, reactive forms, strict TypeScript, responsive SCSS, and API fallback content.
- SEO assets live in `client/src/index.html`, `client/src/app/core/seo`, and `client/public`. Update `https://becherandoura.com` in those files if the production domain changes.
- Logo assets live in `client/public/images/becher-andoura-logo.svg`, `client/public/images/becher-andoura-mark.svg`, and `client/public/favicon.svg`.
