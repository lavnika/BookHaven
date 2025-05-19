import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
    form = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required]
  });

  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) {}

  onSubmit() {
    if (this.form.invalid) return;
    this.auth.login(this.form.value).subscribe({
      next: (res) => {
        this.auth.saveToken(res.token);
        console.log("success");
        this.router.navigate(['/book-list']);
      },
      error: () => alert('Invalid email or password')
    });
  }

}


///////
  
