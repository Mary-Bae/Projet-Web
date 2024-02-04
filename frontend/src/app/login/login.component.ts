import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthentificationService } from '../shared/authentification.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
loginForm:FormGroup;

constructor(private authService: AuthentificationService, private router: Router){
  this.loginForm= new FormGroup({
    username: new FormControl("", [Validators.required, Validators.minLength(4)]),
    password: new FormControl("", [Validators.required,
    Validators.pattern("^(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$")
    ]),
  })
}

login(){
  this.authService.Login(this.loginForm.value.username, this.loginForm.value.password)
  .subscribe(response => {
    console.log(response);
    if(response.token){
      sessionStorage.setItem("jwt", response.token);
      this.router.navigate(["/"])
    }

  })
}
}


