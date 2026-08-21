import { SeoMetadata } from './seo.model';

const siteUrl = 'https://becherandoura.com';
const heroImageUrl = `${siteUrl}/images/becher-hero-workspace.png`;
const logoUrl = `${siteUrl}/images/becher-andoura-logo.svg`;
const logoMarkUrl = `${siteUrl}/images/becher-andoura-mark.svg`;

export const siteSeoMetadata: SeoMetadata = {
  title: 'Becher Andoura | Angular & .NET Website Developer',
  description:
    'Becher Andoura builds modern websites, web applications, and .NET APIs with Angular, clean architecture, responsive design, and reliable delivery.',
  canonicalUrl: `${siteUrl}/`,
  imageUrl: heroImageUrl,
  imageAlt: 'Modern software developer workspace for website and application development',
  imageWidth: 1672,
  imageHeight: 941,
  keywords: [
    'Becher Andoura',
    'software developer',
    'Angular developer',
    '.NET developer',
    'website development',
    'web application development',
    'clean architecture'
  ],
  structuredData: {
    '@context': 'https://schema.org',
    '@graph': [
      {
        '@type': 'Person',
        '@id': `${siteUrl}/#person`,
        name: 'Becher Andoura',
        jobTitle: 'Software Developer',
        url: `${siteUrl}/`,
        image: heroImageUrl,
        logo: logoMarkUrl,
        knowsAbout: ['Angular', '.NET', 'ASP.NET Core', 'TypeScript', 'Clean Architecture', 'Website Development']
      },
      {
        '@type': 'ProfessionalService',
        '@id': `${siteUrl}/#service`,
        name: 'Becher Andoura Website Development',
        url: `${siteUrl}/`,
        description: 'Website and web application development services using Angular and .NET.',
        image: heroImageUrl,
        logo: logoUrl,
        provider: {
          '@id': `${siteUrl}/#person`
        },
        areaServed: 'Worldwide',
        serviceType: ['Website Development', 'Web Application Development', '.NET API Development']
      },
      {
        '@type': 'WebSite',
        '@id': `${siteUrl}/#website`,
        name: 'Becher Andoura',
        url: `${siteUrl}/`,
        inLanguage: 'en',
        publisher: {
          '@id': `${siteUrl}/#person`
        }
      }
    ]
  }
};
