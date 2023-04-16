import { UserDetail } from 'src/app/models/user-detail';
import { Component, OnInit } from '@angular/core';
import { UserWelcomeDetail } from 'src/app/models/user-welcome-detail';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html'
})
export class WelcomeComponent implements OnInit {
  error = { message: '' };
  userWelcomeDetail: UserWelcomeDetail;
  userDetail: UserDetail = history.state?.value;

  constructor(private _userService: UserService) { }

  ngOnInit(): void {
    this._userService.GetUserWelcomeDetails(this.userDetail).subscribe(
      (response: UserWelcomeDetail) => {
        this.userWelcomeDetail = response;
      },
      (error: any) => {
        this.error = { message: error.error.message };
        console.log('Error receiving form data:', error);
      }
    );
  }
}
