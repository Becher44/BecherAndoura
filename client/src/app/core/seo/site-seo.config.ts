import { SeoMetadata } from './seo.model';

const siteUrl = 'https://becherandoura.com';
const heroImageUrl = `${siteUrl}/images/becher-hero-workspace.png`;
const logoUrl = `${siteUrl}/images/becher-andoura-logo.svg`;
const logoMarkUrl = `${siteUrl}/images/becher-andoura-mark.svg`;

export const siteSeoMetadata: SeoMetadata = {
  title: 'Becher Andoura | Website Creation Services',
  description:
    'Request a clear, modern website, quote form, customer portal, or website improvement service from Becher Andoura. No technical explanation required.',
  canonicalUrl: `${siteUrl}/`,
  imageUrl: heroImageUrl,
  imageAlt: 'Modern software developer workspace for website and application development',
  imageWidth: 1672,
  imageHeight: 941,
  keywords: [
    'Becher Andoura',
    'website creation',
    'business website',
    'request website service',
    'quote form',
    'customer portal',
    'website improvement'
  ],
  structuredData: {
    '@context': 'https://schema.org',
    '@graph': [
      {
        '@type': 'Person',
        '@id': `${siteUrl}/#person`,
        name: 'Becher Andoura',
        jobTitle: 'Website Developer and Software Developer',
        url: `${siteUrl}/`,
        image: heroImageUrl,
        logo: logoMarkUrl,
        knowsAbout: ['Website Creation', 'Business Websites', 'Quote Forms', 'Customer Portals', 'Angular', '.NET']
      },
      {
        '@type': 'ProfessionalService',
        '@id': `${siteUrl}/#service`,
        name: 'Becher Andoura Website Development',
        url: `${siteUrl}/`,
        description: 'Website creation, request form, customer portal, and website improvement services for businesses.',
        image: heroImageUrl,
        logo: logoUrl,
        provider: {
          '@id': `${siteUrl}/#person`
        },
        areaServed: 'Worldwide',
        serviceType: [
          'Website Creation',
          'Business Website Development',
          'Quote Request Forms',
          'Customer Portals',
          'Website Improvements'
        ]
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
