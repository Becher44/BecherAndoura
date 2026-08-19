using BecherAndoura.Application.Abstractions;
using BecherAndoura.Domain.Portfolio;

namespace BecherAndoura.Infrastructure.Portfolio;

public sealed class InMemoryPortfolioContentRepository : IPortfolioContentRepository
{
    private static readonly PortfolioContent Content = new(
        new DeveloperProfile(
            "Becher Andoura",
            "Software Developer",
            "Modern websites and web applications built with Angular, .NET, clean architecture, and pragmatic delivery.",
            "I help businesses turn ideas into polished digital products, from service websites and landing pages to API-backed portals, dashboards, and booking flows.",
            "Available for freelance website and web application projects",
            [
                "Angular 22 frontends",
                ".NET 10 APIs",
                "Clean Architecture",
                "Responsive, SEO-ready delivery"
            ]),
        [
            new ServiceOffer(
                "Website Design & Development",
                "Responsive websites that present your offer clearly, load quickly, and convert visitors into leads.",
                [
                    "Portfolio and business websites",
                    "Landing pages for campaigns",
                    "CMS-ready content structure",
                    "Search and accessibility foundations"
                ]),
            new ServiceOffer(
                "Web Applications & Portals",
                "Custom Angular applications for workflows that need forms, dashboards, secure data, and real business logic.",
                [
                    "Admin dashboards",
                    "Client portals",
                    "Booking and request flows",
                    "Role-ready application structure"
                ]),
            new ServiceOffer(
                "API & Backend Engineering",
                ".NET APIs designed around clear contracts, validation, maintainability, and future integrations.",
                [
                    "REST endpoints and OpenAPI",
                    "Clean Architecture layers",
                    "Integrations and automation",
                    "Performance-minded backend design"
                ]),
            new ServiceOffer(
                "Modernization & Care",
                "Upgrade older sites or applications with stronger UX, cleaner code, better performance, and a safer delivery path.",
                [
                    "Angular and .NET upgrades",
                    "Performance improvements",
                    "Bug fixing and refactoring",
                    "Deployment support"
                ])
        ],
        [
            new ProcessStep("Discover", "Clarify the audience, offer, pages, integrations, and success metrics before writing code."),
            new ProcessStep("Structure", "Model the domain, content, API contracts, and component boundaries so the project can grow cleanly."),
            new ProcessStep("Build", "Develop in focused slices with Angular, .NET, validation, responsive UI, and maintainable patterns."),
            new ProcessStep("Launch", "Prepare production settings, polish edge cases, and hand over a codebase that is easy to continue.")
        ],
        [
            new ProjectCaseStudy(
                "Service Business Website",
                "Marketing site",
                "A polished service website structure for explaining offers, building trust, and turning visitors into inquiries.",
                [
                    "Conversion-first page flow",
                    "Fast responsive layout",
                    "Clear service and contact sections"
                ]),
            new ProjectCaseStudy(
                "Operations Portal",
                "Angular web app",
                "A dashboard-style application foundation for managing forms, statuses, internal workflows, and secure API data.",
                [
                    "Reusable component structure",
                    "API-driven data model",
                    "Scalable feature organization"
                ]),
            new ProjectCaseStudy(
                "API-Backed Booking Flow",
                ".NET integration",
                "A backend-first flow for collecting requests, validating data, and preparing integrations with scheduling or CRM tools.",
                [
                    "Validation and error handling",
                    "OpenAPI-ready endpoints",
                    "Clean service boundaries"
                ])
        ],
        [
            new TechnologyGroup("Frontend", ["Angular 22", "TypeScript", "Signals", "Reactive Forms", "SCSS"]),
            new TechnologyGroup("Backend", [".NET 10", "ASP.NET Core", "Minimal APIs", "OpenAPI", "Dependency Injection"]),
            new TechnologyGroup("Architecture", ["SOLID", "Clean Architecture", "Repository Pattern", "DTO contracts", "Validation"]),
            new TechnologyGroup("Delivery", ["Responsive UI", "Accessibility basics", "Performance budgets", "Deployment-ready setup"])
        ],
        [
            new ClientOutcome("4", "service tracks"),
            new ClientOutcome("10", "technology baseline"),
            new ClientOutcome("100%", "responsive layout"),
            new ClientOutcome("1", "clear contact path")
        ]);

    public Task<PortfolioContent> GetAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(Content);
    }
}
