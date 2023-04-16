import { TestBed } from '@angular/core/testing';
import { HttpTestingController, HttpClientTestingModule } from '@angular/common/http/testing';
import { UserService } from './user.service';
import { UserDetail } from '../models/user-detail';
import { UserWelcomeDetail } from '../models/user-welcome-detail';

describe('UserService', () => {
  let userService: UserService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [UserService],
    });
    httpMock = TestBed.inject(HttpTestingController);
    userService = TestBed.inject(UserService);
  });

  it('should be created', () => {
    expect(userService).toBeTruthy();
  });

  it('should return user welcome details', () => {
    // Arrange
    const userDetail: UserDetail = { fullName: "Daniele Morina", dateOfBirth: new Date(1986, 9, 28) };
    const userWelcomeDetail: UserWelcomeDetail = { name: "Daniele Morina", numberOfVowelsInName: 4, age: 36 };

    // Act
    userService.GetUserWelcomeDetails(userDetail).subscribe((response: UserWelcomeDetail) => {
      // Assert
      expect(response).toEqual(userWelcomeDetail);
    });
  });

  it('should throw an error if the API call fails', () => {
    // Arrange
    const userDetail: UserDetail = { fullName: "Daniele Morina", dateOfBirth: new Date(1986, 9, 28) };
    const errorMessage: string = 'Something went wrong';

    // Act
    userService.GetUserWelcomeDetails(userDetail).subscribe(
      () => {},
      (error: any) => {
        // Assert
        expect(error).toBe(errorMessage);
      }
    );
  });
});
