import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
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
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { StorekeeperComponent } from './components/storekeeper/storekeeper.component';
import { DetailComponent } from './components/detail/detail.component';

import { DetailService } from './services/detail.service';
import { StorekeeperService } from './services/storekeeper.service';

@NgModule({
    declarations: [
        AppComponent,
        StorekeeperComponent,
        DetailComponent,
        NavMenuComponent
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
            { path: '', redirectTo: 'detail', pathMatch: 'full' },
            { path: 'storekeeper', component: StorekeeperComponent },
            { path: 'detail', component: DetailComponent }
        ])
    ],
    providers: [StorekeeperService,
        DetailService],
    bootstrap: [AppComponent]
})
export class AppModule { }