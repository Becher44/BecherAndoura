namespace BecherAndoura.Domain.Portfolio;

public sealed record PortfolioContent(
    DeveloperProfile Profile,
    IReadOnlyList<ServiceOffer> Services,
    IReadOnlyList<ProcessStep> Process,
    IReadOnlyList<ProjectCaseStudy> Projects,
    IReadOnlyList<TechnologyGroup> Technologies,
    IReadOnlyList<ClientOutcome> Outcomes);

public sealed record DeveloperProfile(
    string Name,
    string Role,
    string Tagline,
    string Bio,
    string Availability,
    IReadOnlyList<string> Highlights);

public sealed record ServiceOffer(
    string Title,
    string Summary,
    IReadOnlyList<string> Deliverables);

public sealed record ProcessStep(
    string Name,
    string Description);

public sealed record ProjectCaseStudy(
    string Name,
    string Type,
    string Summary,
    IReadOnlyList<string> Results);

public sealed record TechnologyGroup(
    string Name,
    IReadOnlyList<string> Items);

public sealed record ClientOutcome(
    string Metric,
    string Label);
