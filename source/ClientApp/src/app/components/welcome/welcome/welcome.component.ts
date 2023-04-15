import { Component, OnInit } from '@angular/core';
import { UserDetail } from 'src/app/models/user-detail';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
})
export class WelcomeComponent implements OnInit {
  formData = history.state?.value;
  error = { message: '' };
  upcomingBirthdayDates: Date[];
  userDetail: UserDetail;

  constructor(private _userService: UserService) { }

  ngOnInit(): void {
    this._userService.GetUserWelcomeDetails(this.formData).subscribe(
      (response: UserDetail) => {
        this.userDetail = response;
        console.log('Form data received successfully', response);
      },
      (error: any) => {
        this.error = {
          message: error.error.message
        };
        console.log('Error receiving form data:', error);
      }
    );
  }
}
