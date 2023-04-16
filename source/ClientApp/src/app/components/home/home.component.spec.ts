import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { HomeComponent } from './home.component';
import { Router } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;
  let router: Router;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomeComponent ],
      imports: [ ReactiveFormsModule, RouterTestingModule ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
    router = TestBed.inject(Router);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should navigate to welcome page on submit', () => {
    // Arrange
    const navigateSpy = spyOn(router, 'navigate');
    component.myForm.setValue({ fullName: "Daniele Morina", dateOfBirth: new Date(1986, 9, 28) });

    // Act
    component.onSubmit();

    // Assert
    expect(navigateSpy).toHaveBeenCalledWith(['/welcome'], { state: { value: { fullName: "Daniele Morina", dateOfBirth: new Date(1986, 9, 28) } } });
  });
});
