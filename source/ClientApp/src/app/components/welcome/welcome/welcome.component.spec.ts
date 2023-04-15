import { ComponentFixture, TestBed } from '@angular/core/testing';
import { WelcomeComponent } from './welcome.component';
import { UserService } from 'src/app/services/user.service';
import { Observable, of } from 'rxjs';
import { UserDetail } from '../../../models/user-detail';
import { HttpClientModule } from '@angular/common/http';

const mockUserService = {
  GetUserWelcomeDetails(formData: any): Observable<UserDetail> {
    return of({} as UserDetail);
  }
} as UserService;

fdescribe('WelcomeComponent', () => {
  let component: WelcomeComponent;
  let fixture: ComponentFixture<WelcomeComponent>;
  //let mockUserService: jasmine.SpyObj<UserService>;

  beforeEach(async () => {
    //mockUserService = jasmine.createSpyObj<UserService>('UserService', ['GetUserWelcomeDetails'])

    await TestBed.configureTestingModule({
      declarations: [ WelcomeComponent ],
      providers:[
        { provider: UserService, useValue: mockUserService}
      ],
      imports: [HttpClientModule],
    })
    .compileComponents();

    fixture = TestBed.createComponent(WelcomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

