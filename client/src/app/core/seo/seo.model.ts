export interface SeoMetadata {
  title: string;
  description: string;
  canonicalUrl: string;
  imageUrl: string;
  imageAlt: string;
  imageWidth: number;
  imageHeight: number;
  keywords: string[];
  structuredData: Record<string, unknown>;
}
