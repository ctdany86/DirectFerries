import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  myForm: FormGroup;

  constructor(private _router: Router) { }

  ngOnInit() {
    this.myForm = new FormGroup({
      fullName: new FormControl(''),
      dateOfBirth: new FormControl('')
    });
  }

  onSubmit() {
    this._router.navigate(['/welcome'], { state: { value: this.myForm.value } });
  }
}
