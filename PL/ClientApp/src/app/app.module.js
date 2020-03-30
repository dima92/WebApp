var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
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
let AppModule = class AppModule {
};
AppModule = __decorate([
    NgModule({
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
            BrowserAnimationsModule,
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
], AppModule);
export { AppModule };
//# sourceMappingURL=app.module.js.map