import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthenticationService } from '../../../../shared/services/authentication.service';
import { AppUserViewModel } from '../../../../shared/models/user/app-user-view.model';
import { Router } from '@angular/router';
import { ApiRoute } from '../../../../shared/utilities/api-route';

@Component({
  selector: 'mh-system-header',
  templateUrl: './system-header.component.html',
  styleUrls: ['./system-header.component.scss']
})
export class SystemHeaderComponent implements OnInit {
  user: AppUserViewModel;
  @Output() toggleSidenav = new EventEmitter();
  @Input() screenWidth: number;

  constructor(private router: Router, private authService: AuthenticationService) { }

  ngOnInit() {
    this.user = this.authService.currentUser;
  }

  logOut() {
    this.authService.logout();
    this.router.navigateByUrl('/' + ApiRoute.Login);
  }
}
