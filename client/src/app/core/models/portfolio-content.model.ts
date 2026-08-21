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
  projectType: string;
  message: string;
}

export interface ContactResponse {
  message: string;
}

export const fallbackPortfolioContent: PortfolioContent = {
  profile: {
    name: 'Becher Andoura',
    role: 'Website Developer & Software Developer',
    tagline: 'I create clear, modern websites for businesses that want more customers, more trust, and an easier way to receive requests online.',
    bio: 'Whether you need a simple business website, a booking form, a customer portal, or improvements to an existing site, I can help you plan it, build it, and launch it.',
    availability: 'Available for website creation, redesigns, forms, portals, and ongoing support',
    highlights: [
      'Business websites',
      'Service request forms',
      'Customer portals',
      'Website fixes and improvements'
    ]
  },
  services: [
    {
      title: 'Create a New Website',
      summary: 'A professional website that explains who you are, what you offer, and how customers can contact you.',
      deliverables: [
        'Home, about, services, and contact pages',
        'Mobile-friendly design',
        'Clear calls to action',
        'Basic SEO setup'
      ]
    },
    {
      title: 'Add Forms and Requests',
      summary: 'Make it easy for visitors to send inquiries, ask for quotes, book a service, or share project details.',
      deliverables: [
        'Contact and quote forms',
        'Booking request flows',
        'Email or database-ready submissions',
        'Simple admin-friendly structure'
      ]
    },
    {
      title: 'Build a Customer Portal',
      summary: 'A private area where customers or staff can log in, view information, send updates, or manage requests.',
      deliverables: [
        'Client dashboards',
        'Request tracking',
        'Secure backend APIs',
        'Future integration support'
      ]
    },
    {
      title: 'Improve an Existing Website',
      summary: 'Refresh an old website so it looks better, works faster, and is easier for customers to use.',
      deliverables: [
        'Better layout and content',
        'Performance improvements',
        'Bug fixes',
        'Launch and support help'
      ]
    }
  ],
  process: [
    {
      name: 'Tell Me What You Need',
      description: 'You describe your business, your service, and what customers should be able to do on the website.'
    },
    {
      name: 'Get a Clear Plan',
      description: 'I turn your idea into pages, features, timeline, and next steps written in simple language.'
    },
    {
      name: 'Watch It Take Shape',
      description: 'I build the website in small visible steps so you can review the content and design early.'
    },
    {
      name: 'Launch With Confidence',
      description: 'I help prepare the final version, connect the request form, and explain how the website works.'
    }
  ],
  projects: [
    {
      name: 'Business Website',
      type: 'Most requested',
      summary: 'A website for a company, freelancer, clinic, agency, restaurant, or local service provider.',
      results: [
        'Explain services clearly',
        'Build trust with customers',
        'Receive calls, messages, or quote requests'
      ]
    },
    {
      name: 'Booking or Quote Request',
      type: 'Customer action',
      summary: 'A simple online flow where visitors tell you what they need without calling first.',
      results: [
        'Collect customer details',
        'Ask the right questions',
        'Save time before the first conversation'
      ]
    },
    {
      name: 'Client or Staff Portal',
      type: 'Custom system',
      summary: 'A secure web app for customers, employees, or partners who need to view and manage information.',
      results: [
        'Organize requests',
        'Show useful status updates',
        'Prepare for future business growth'
      ]
    }
  ],
  technologies: [
    {
      name: 'What Customers See',
      items: ['Clear pages', 'Fast loading', 'Mobile layout', 'Easy contact buttons']
    },
    {
      name: 'What You Receive',
      items: ['Website files', 'Request form', 'Admin-ready structure', 'Launch guidance']
    },
    {
      name: 'Built With',
      items: ['Angular', '.NET', 'Secure APIs', 'Clean code']
    },
    {
      name: 'Prepared For',
      items: ['SEO basics', 'Accessibility basics', 'Future features', 'Ongoing support']
    }
  ],
  outcomes: [
    {
      metric: '1',
      label: 'simple request form'
    },
    {
      metric: '4',
      label: 'common service options'
    },
    {
      metric: '100%',
      label: 'mobile-friendly'
    },
    {
      metric: '0',
      label: 'technical words needed'
    }
  ]
};
