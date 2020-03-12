import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { StorekeeperComponent } from './storekeeper/storekeeper.component';
import { DetailComponent } from './detail/detail.component';

import { StorekeeperService } from './service/storekeeper.service';
import { DetailService } from './service/detail.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    StorekeeperComponent,
    DetailComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    MatDialogModule,
    FormsModule,
    MatButtonModule,
    MatInputModule,
    MatIconModule,
    MatSortModule,
    MatTableModule,
    MatToolbarModule,
    MatPaginatorModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: '/api/storekeepers', pathMatch: 'full' },
      { path: 'api/storekeepers', component: StorekeeperComponent },
      { path: 'api/details', component: DetailComponent }
    ])
  ],
  providers: [StorekeeperService,
    DetailService],
  bootstrap: [AppComponent]
})
export class AppModule { }
