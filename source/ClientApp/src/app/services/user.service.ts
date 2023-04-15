import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserDetail } from '../models/user-detail';
import { map, catchError, throwError, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private userUrl: string = 'http://localhost:5168/user'

  constructor(private http: HttpClient) { }

  GetUserWelcomeDetails(formData: any): Observable<UserDetail> {
    return this.http.get<UserDetail>(`${this.userUrl}/get-user-welcome-page?fullName=${formData.fullName}&dateOfBirth=${formData.dateOfBirth}`).pipe(
      map((response: UserDetail) => response),
      catchError((error: any) => throwError(error))
    );
  }
}
