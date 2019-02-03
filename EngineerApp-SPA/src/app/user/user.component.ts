import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  userForm: FormGroup;
  constructor(private authService: AuthService, private alertify: AlertifyService, private fb: FormBuilder,
    private router: Router) { }

  ngOnInit() {
    this.createUserForm();
  }

  createUserForm() {
    this.userForm = this.fb.group({
      password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(15)]],
      passwordConfirm: ['', Validators.required]
    }, {validator: this.passwordMatchValidate});
  }

  passwordMatchValidate(g: FormGroup) {
    return g.get('password').value === g.get('passwordConfirm').value ? null : {'mismatch': true};
  }

  changePassword() {
    if (this.userForm.valid) {
      this.authService.changePassword(this.userForm.value).subscribe(() => {
        this.alertify.warning('Password has been changed.');
        this.router.navigateByUrl('/home');
      }, error => {
        this.alertify.error(error);
      });
    }
  }

  cancel() {
    this.router.navigateByUrl('/home');
  }
}
