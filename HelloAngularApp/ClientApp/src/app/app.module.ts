import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';

// определение маршрутов
const appRoutes: Routes = [
    { path: '', component: ProductListComponent },
    { path: 'product/:id', component: ProductDetailComponent },
    { path: '**', redirectTo: '/' }
];

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations: [AppComponent, ProductListComponent, ProductDetailComponent],
    bootstrap: [AppComponent]
})

export class AppModule { }