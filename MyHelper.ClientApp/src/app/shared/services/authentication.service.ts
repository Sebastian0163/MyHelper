import { Injectable } from '@angular/core';
import {
  HttpClient, HttpHeaders,
} from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AppUserViewModel } from '../models/user/app-user-view.model';
import { LoginRequest } from '../models/auth/login-request.model';
import { Observable } from 'rxjs/Observable';
import '../utilities/rxjs-operators';
import { ApiRoute } from '../utilities/api-route';
import { RegistrationRequest } from '../models/auth/registration-request.model';
import { AuthorizationTokenResponse } from '../models/auth/authorization-token-response.model';
import { BaseService } from './base.service';
import { IServerResponse } from '../models/base/server-response.model';
import { RequestMethod } from '../utilities/enums';

@Injectable()
export class AuthenticationService extends BaseService {

  private _jwtConfig = { tokenGetter: () => this.token ? this.token : null };
  private _jwtHelperService: JwtHelperService = new JwtHelperService(this._jwtConfig);

  get currentUser(): AppUserViewModel {
    const currentUser = JSON.parse(localStorage.getItem('currentUser'));
    return currentUser;
  }

  set currentUser(currentUser: AppUserViewModel) {
    localStorage.setItem('currentUser', JSON.stringify(currentUser));
  }

  get token(): string {
    const token = JSON.parse(localStorage.getItem('token'));
    return token;
  }

  constructor(protected httpClient: HttpClient) {
    super(httpClient);
  }

  login(loginRequest: LoginRequest): Observable<boolean> {
    return this.sendRequest(RequestMethod.Post, ApiRoute.Login, loginRequest, null, null, this._handleResponse.bind(this));
  }

  logout() {
    localStorage.removeItem('currentUser');
    localStorage.removeItem('token');
  }

  createUser(registrationRequest: RegistrationRequest): Observable<boolean> {
    return this.sendRequest(RequestMethod.Post, ApiRoute.Registration, registrationRequest, null, null, this._handleResponse.bind(this));
  }

  isLoggedIn(): boolean {
      return this.token && !this._jwtHelperService.isTokenExpired(this.token);
  }

  private _handleResponse(response: IServerResponse): boolean {
    if (response.isSuccess && response.result) {
      this.currentUser = response.result.appUserViewModel;
      localStorage.setItem('token', JSON.stringify(response.result.token));
      return true;
    } else {
      return false;
    }
  }
}
