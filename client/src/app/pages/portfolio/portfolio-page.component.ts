import { ChangeDetectionStrategy, Component, inject, OnInit, signal } from '@angular/core';
import { NonNullableFormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { PortfolioApiService } from '../../core/services/portfolio-api.service';

type ContactStatus = 'idle' | 'sending' | 'sent' | 'error';
type ContactControlName = 'name' | 'email' | 'company' | 'budget' | 'message';

@Component({
  selector: 'app-portfolio-page',
  imports: [ReactiveFormsModule],
  templateUrl: './portfolio-page.component.html',
  styleUrl: './portfolio-page.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PortfolioPageComponent implements OnInit {
  private readonly formBuilder = inject(NonNullableFormBuilder);
  readonly portfolio = inject(PortfolioApiService);
  readonly content = this.portfolio.content;
  readonly contactStatus = signal<ContactStatus>('idle');
  readonly currentYear = new Date().getFullYear();

  readonly contactForm = this.formBuilder.group({
    name: ['', [Validators.required, Validators.maxLength(120)]],
    email: ['', [Validators.required, Validators.email, Validators.maxLength(180)]],
    company: ['', [Validators.maxLength(160)]],
    budget: ['', [Validators.maxLength(120)]],
    message: ['', [Validators.required, Validators.minLength(20), Validators.maxLength(1500)]]
  });

  ngOnInit(): void {
    this.portfolio.load();
  }

  getControlError(controlName: ContactControlName): string {
    const control = this.contactForm.controls[controlName];

    if (!(control.touched || control.dirty) || control.valid) {
      return '';
    }

    if (control.hasError('required')) {
      return 'Required';
    }

    if (control.hasError('email')) {
      return 'Use a valid email';
    }

    if (control.hasError('minlength')) {
      return 'Add more detail';
    }

    if (control.hasError('maxlength')) {
      return 'Too long';
    }

    return 'Check this field';
  }

  submitContact(): void {
    if (this.contactForm.invalid) {
      this.contactForm.markAllAsTouched();
      return;
    }

    this.contactStatus.set('sending');

    this.portfolio.sendContact(this.contactForm.getRawValue()).subscribe({
      next: () => {
        this.contactStatus.set('sent');
        this.contactForm.reset();
      },
      error: () => this.contactStatus.set('error')
    });
  }

  scrollToContact(): void {
    document.getElementById('contact')?.scrollIntoView({
      behavior: 'smooth',
      block: 'start'
    });
  }
}
