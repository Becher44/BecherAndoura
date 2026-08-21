import { HttpClient } from '@angular/common/http';
import { computed, inject, Injectable, signal } from '@angular/core';
import { catchError, finalize, Observable, of, tap } from 'rxjs';
import {
  ContactPayload,
  ContactResponse,
  fallbackPortfolioContent,
  PortfolioContent
} from '../models/portfolio-content.model';

@Injectable({
  providedIn: 'root'
})
export class PortfolioApiService {
  private readonly http = inject(HttpClient);
  private readonly contentSignal = signal<PortfolioContent | null>(null);
  private readonly loadingSignal = signal(false);
  private readonly errorSignal = signal<string | null>(null);

  readonly content = computed(() => this.contentSignal() ?? fallbackPortfolioContent);
  readonly loading = this.loadingSignal.asReadonly();
  readonly error = this.errorSignal.asReadonly();

  load(): void {
    if (this.loadingSignal() || this.contentSignal()) {
      return;
    }

    this.loadingSignal.set(true);
    this.errorSignal.set(null);

    this.http
      .get<PortfolioContent>('/api/portfolio')
      .pipe(
        tap((content) => this.contentSignal.set(content)),
        catchError(() => {
          this.errorSignal.set('Showing website details while the form service starts.');
          return of(null);
        }),
        finalize(() => this.loadingSignal.set(false))
      )
      .subscribe();
  }

  sendContact(payload: ContactPayload): Observable<ContactResponse> {
    return this.http.post<ContactResponse>('/api/contact', payload);
  }
}
