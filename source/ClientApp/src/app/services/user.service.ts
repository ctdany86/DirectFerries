import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserDetail } from '../models/user-detail';
import { map, catchError, throwError, Observable } from 'rxjs';
import { UserWelcomeDetail } from '../models/user-welcome-detail';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private userUrl: string = 'http://localhost:5168/user'

  constructor(private http: HttpClient) { }

  GetUserWelcomeDetails(userDetail: UserDetail): Observable<UserWelcomeDetail> {
    console.log('User reponse', userDetail);
    return this.http.get<UserWelcomeDetail>(`${this.userUrl}/get-user-welcome-page?fullName=${userDetail.fullName}&dateOfBirth=${userDetail.dateOfBirth}`).pipe(
      map((response: UserWelcomeDetail) => {
        console.log('User reponse', response);
        return response
      }),
      catchError((error: any) => throwError(error))
    );
  }
}
