import { DOCUMENT } from '@angular/common';
import { inject, Injectable } from '@angular/core';
import { Meta, Title } from '@angular/platform-browser';
import { SeoMetadata } from './seo.model';

@Injectable({
  providedIn: 'root'
})
export class SeoService {
  private readonly document = inject(DOCUMENT);
  private readonly meta = inject(Meta);
  private readonly title = inject(Title);

  apply(metadata: SeoMetadata): void {
    this.title.setTitle(metadata.title);
    this.setNameTag('description', metadata.description);
    this.setNameTag('robots', 'index, follow, max-image-preview:large');
    this.setNameTag('author', 'Becher Andoura');
    this.setNameTag('keywords', metadata.keywords.join(', '));
    this.setNameTag('theme-color', '#101820');

    this.setPropertyTag('og:type', 'website');
    this.setPropertyTag('og:site_name', 'Becher Andoura');
    this.setPropertyTag('og:title', metadata.title);
    this.setPropertyTag('og:description', metadata.description);
    this.setPropertyTag('og:url', metadata.canonicalUrl);
    this.setPropertyTag('og:image', metadata.imageUrl);
    this.setPropertyTag('og:image:alt', metadata.imageAlt);
    this.setPropertyTag('og:image:width', String(metadata.imageWidth));
    this.setPropertyTag('og:image:height', String(metadata.imageHeight));

    this.setNameTag('twitter:card', 'summary_large_image');
    this.setNameTag('twitter:title', metadata.title);
    this.setNameTag('twitter:description', metadata.description);
    this.setNameTag('twitter:image', metadata.imageUrl);

    this.setCanonical(metadata.canonicalUrl);
    this.setStructuredData(metadata.structuredData);
  }

  private setNameTag(name: string, content: string): void {
    this.meta.updateTag({ name, content });
  }

  private setPropertyTag(property: string, content: string): void {
    this.meta.updateTag({ property, content });
  }

  private setCanonical(url: string): void {
    let canonical = this.document.querySelector<HTMLLinkElement>('link[rel="canonical"]');

    if (!canonical) {
      canonical = this.document.createElement('link');
      canonical.rel = 'canonical';
      this.document.head.appendChild(canonical);
    }

    canonical.href = url;
  }

  private setStructuredData(data: Record<string, unknown>): void {
    this.document.getElementById('structured-data')?.remove();

    const script = this.document.createElement('script');
    script.id = 'structured-data';
    script.type = 'application/ld+json';
    script.text = JSON.stringify(data);

    this.document.head.appendChild(script);
  }
}
