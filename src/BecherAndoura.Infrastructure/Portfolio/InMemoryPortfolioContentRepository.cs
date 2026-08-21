using BecherAndoura.Application.Abstractions;
using BecherAndoura.Domain.Portfolio;

namespace BecherAndoura.Infrastructure.Portfolio;

public sealed class InMemoryPortfolioContentRepository : IPortfolioContentRepository
{
    private static readonly PortfolioContent Content = new(
        new DeveloperProfile(
            "Becher Andoura",
            "Website Developer & Software Developer",
            "I create clear, modern websites for businesses that want more customers, more trust, and an easier way to receive requests online.",
            "Whether you need a simple business website, a booking form, a customer portal, or improvements to an existing site, I can help you plan it, build it, and launch it.",
            "Available for website creation, redesigns, forms, portals, and ongoing support",
            [
                "Business websites",
                "Service request forms",
                "Customer portals",
                "Website fixes and improvements"
            ]),
        [
            new ServiceOffer(
                "Create a New Website",
                "A professional website that explains who you are, what you offer, and how customers can contact you.",
                [
                    "Home, about, services, and contact pages",
                    "Mobile-friendly design",
                    "Clear calls to action",
                    "Basic SEO setup"
                ]),
            new ServiceOffer(
                "Add Forms and Requests",
                "Make it easy for visitors to send inquiries, ask for quotes, book a service, or share project details.",
                [
                    "Contact and quote forms",
                    "Booking request flows",
                    "Email or database-ready submissions",
                    "Simple admin-friendly structure"
                ]),
            new ServiceOffer(
                "Build a Customer Portal",
                "A private area where customers or staff can log in, view information, send updates, or manage requests.",
                [
                    "Client dashboards",
                    "Request tracking",
                    "Secure backend APIs",
                    "Future integration support"
                ]),
            new ServiceOffer(
                "Improve an Existing Website",
                "Refresh an old website so it looks better, works faster, and is easier for customers to use.",
                [
                    "Better layout and content",
                    "Performance improvements",
                    "Bug fixes",
                    "Launch and support help"
                ])
        ],
        [
            new ProcessStep("Tell Me What You Need", "You describe your business, your service, and what customers should be able to do on the website."),
            new ProcessStep("Get a Clear Plan", "I turn your idea into pages, features, timeline, and next steps written in simple language."),
            new ProcessStep("Watch It Take Shape", "I build the website in small visible steps so you can review the content and design early."),
            new ProcessStep("Launch With Confidence", "I help prepare the final version, connect the request form, and explain how the website works.")
        ],
        [
            new ProjectCaseStudy(
                "Business Website",
                "Most requested",
                "A website for a company, freelancer, clinic, agency, restaurant, or local service provider.",
                [
                    "Explain services clearly",
                    "Build trust with customers",
                    "Receive calls, messages, or quote requests"
                ]),
            new ProjectCaseStudy(
                "Booking or Quote Request",
                "Customer action",
                "A simple online flow where visitors tell you what they need without calling first.",
                [
                    "Collect customer details",
                    "Ask the right questions",
                    "Save time before the first conversation"
                ]),
            new ProjectCaseStudy(
                "Client or Staff Portal",
                "Custom system",
                "A secure web app for customers, employees, or partners who need to view and manage information.",
                [
                    "Organize requests",
                    "Show useful status updates",
                    "Prepare for future business growth"
                ])
        ],
        [
            new TechnologyGroup("What Customers See", ["Clear pages", "Fast loading", "Mobile layout", "Easy contact buttons"]),
            new TechnologyGroup("What You Receive", ["Website files", "Request form", "Admin-ready structure", "Launch guidance"]),
            new TechnologyGroup("Built With", ["Angular", ".NET", "Secure APIs", "Clean code"]),
            new TechnologyGroup("Prepared For", ["SEO basics", "Accessibility basics", "Future features", "Ongoing support"])
        ],
        [
            new ClientOutcome("1", "simple request form"),
            new ClientOutcome("4", "common service options"),
            new ClientOutcome("100%", "mobile-friendly"),
            new ClientOutcome("0", "technical words needed")
        ]);

    public Task<PortfolioContent> GetAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(Content);
    }
}
