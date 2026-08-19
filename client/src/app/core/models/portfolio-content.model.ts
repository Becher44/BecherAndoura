export interface PortfolioContent {
  profile: DeveloperProfile;
  services: ServiceOffer[];
  process: ProcessStep[];
  projects: ProjectCaseStudy[];
  technologies: TechnologyGroup[];
  outcomes: ClientOutcome[];
}

export interface DeveloperProfile {
  name: string;
  role: string;
  tagline: string;
  bio: string;
  availability: string;
  highlights: string[];
}

export interface ServiceOffer {
  title: string;
  summary: string;
  deliverables: string[];
}

export interface ProcessStep {
  name: string;
  description: string;
}

export interface ProjectCaseStudy {
  name: string;
  type: string;
  summary: string;
  results: string[];
}

export interface TechnologyGroup {
  name: string;
  items: string[];
}

export interface ClientOutcome {
  metric: string;
  label: string;
}

export interface ContactPayload {
  name: string;
  email: string;
  company: string;
  budget: string;
  message: string;
}

export interface ContactResponse {
  message: string;
}

export const fallbackPortfolioContent: PortfolioContent = {
  profile: {
    name: 'Becher Andoura',
    role: 'Software Developer',
    tagline: 'Modern websites and web applications built with Angular, .NET, clean architecture, and pragmatic delivery.',
    bio: 'I help businesses turn ideas into polished digital products, from service websites and landing pages to API-backed portals, dashboards, and booking flows.',
    availability: 'Available for freelance website and web application projects',
    highlights: [
      'Angular 22 frontends',
      '.NET 10 APIs',
      'Clean Architecture',
      'Responsive, SEO-ready delivery'
    ]
  },
  services: [
    {
      title: 'Website Design & Development',
      summary: 'Responsive websites that present your offer clearly, load quickly, and convert visitors into leads.',
      deliverables: [
        'Portfolio and business websites',
        'Landing pages for campaigns',
        'CMS-ready content structure',
        'Search and accessibility foundations'
      ]
    },
    {
      title: 'Web Applications & Portals',
      summary: 'Custom Angular applications for workflows that need forms, dashboards, secure data, and real business logic.',
      deliverables: [
        'Admin dashboards',
        'Client portals',
        'Booking and request flows',
        'Role-ready application structure'
      ]
    },
    {
      title: 'API & Backend Engineering',
      summary: '.NET APIs designed around clear contracts, validation, maintainability, and future integrations.',
      deliverables: [
        'REST endpoints and OpenAPI',
        'Clean Architecture layers',
        'Integrations and automation',
        'Performance-minded backend design'
      ]
    },
    {
      title: 'Modernization & Care',
      summary: 'Upgrade older sites or applications with stronger UX, cleaner code, better performance, and a safer delivery path.',
      deliverables: [
        'Angular and .NET upgrades',
        'Performance improvements',
        'Bug fixing and refactoring',
        'Deployment support'
      ]
    }
  ],
  process: [
    {
      name: 'Discover',
      description: 'Clarify the audience, offer, pages, integrations, and success metrics before writing code.'
    },
    {
      name: 'Structure',
      description: 'Model the domain, content, API contracts, and component boundaries so the project can grow cleanly.'
    },
    {
      name: 'Build',
      description: 'Develop in focused slices with Angular, .NET, validation, responsive UI, and maintainable patterns.'
    },
    {
      name: 'Launch',
      description: 'Prepare production settings, polish edge cases, and hand over a codebase that is easy to continue.'
    }
  ],
  projects: [
    {
      name: 'Service Business Website',
      type: 'Marketing site',
      summary: 'A polished service website structure for explaining offers, building trust, and turning visitors into inquiries.',
      results: [
        'Conversion-first page flow',
        'Fast responsive layout',
        'Clear service and contact sections'
      ]
    },
    {
      name: 'Operations Portal',
      type: 'Angular web app',
      summary: 'A dashboard-style application foundation for managing forms, statuses, internal workflows, and secure API data.',
      results: [
        'Reusable component structure',
        'API-driven data model',
        'Scalable feature organization'
      ]
    },
    {
      name: 'API-Backed Booking Flow',
      type: '.NET integration',
      summary: 'A backend-first flow for collecting requests, validating data, and preparing integrations with scheduling or CRM tools.',
      results: [
        'Validation and error handling',
        'OpenAPI-ready endpoints',
        'Clean service boundaries'
      ]
    }
  ],
  technologies: [
    {
      name: 'Frontend',
      items: ['Angular 22', 'TypeScript', 'Signals', 'Reactive Forms', 'SCSS']
    },
    {
      name: 'Backend',
      items: ['.NET 10', 'ASP.NET Core', 'Minimal APIs', 'OpenAPI', 'Dependency Injection']
    },
    {
      name: 'Architecture',
      items: ['SOLID', 'Clean Architecture', 'Repository Pattern', 'DTO contracts', 'Validation']
    },
    {
      name: 'Delivery',
      items: ['Responsive UI', 'Accessibility basics', 'Performance budgets', 'Deployment-ready setup']
    }
  ],
  outcomes: [
    {
      metric: '4',
      label: 'service tracks'
    },
    {
      metric: '10',
      label: 'technology baseline'
    },
    {
      metric: '100%',
      label: 'responsive layout'
    },
    {
      metric: '1',
      label: 'clear contact path'
    }
  ]
};
