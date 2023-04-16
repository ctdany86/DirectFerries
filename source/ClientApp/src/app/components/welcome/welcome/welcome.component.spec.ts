import { ComponentFixture, TestBed } from '@angular/core/testing';
import { WelcomeComponent } from './welcome.component';
import { UserService } from 'src/app/services/user.service';
import { Observable, of, throwError } from 'rxjs';
import { UserDetail } from '../../../models/user-detail';
import { HttpClientModule } from '@angular/common/http';
import { UserWelcomeDetail } from 'src/app/models/user-welcome-detail';

const mockUserService = {
  GetUserWelcomeDetails(userDetail: UserDetail): Observable<UserWelcomeDetail> {
    return of({ name: "Daniele Morina", numberOfVowelsInName: 4, age: 36 } as UserWelcomeDetail);
  }
} as UserService;

describe('WelcomeComponent', () => {
  let component: WelcomeComponent;
  let fixture: ComponentFixture<WelcomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WelcomeComponent ],
      providers:[
        { provide: UserService, useValue: mockUserService}
      ],
      imports: [HttpClientModule],
    })
    .compileComponents();

    fixture = TestBed.createComponent(WelcomeComponent);
    component = fixture.componentInstance;
    component.userDetail = { fullName: "Daniele Morina", dateOfBirth: new Date() };
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should get user welcome details on init', () => {
    // Arrange
    const userDetail: UserDetail = { fullName: "Daniele Morina", dateOfBirth: new Date(1986, 9, 28) };
    const userWelcomeDetail: UserWelcomeDetail = { name: "Daniele Morina", numberOfVowelsInName: 4, age: 36 };
    component.userDetail = userDetail;

    // Act
    fixture.detectChanges();

    // Assert
    expect(component.userWelcomeDetail).toEqual(userWelcomeDetail);
  });
});

