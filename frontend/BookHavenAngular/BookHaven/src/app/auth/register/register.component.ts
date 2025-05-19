import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: false,
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  form = this.fb.group({
    fullName: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required],
    city: [''],
    address: [''],
    latitude: [null],
    longitude: [null]

  });

  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) {}

  onSubmit() {
    if (this.form.invalid) return;
      console.log('Form data being sent:', this.form.value); // Log sent data

    this.auth.register(this.form.value).subscribe({
      next: (res) => {
        this.auth.saveToken(res.token);
        this.router.navigate(['/book-list']);
      },
      error: () => alert('Registration failed')
    });
  }
}
