import { NgModule, importProvidersFrom } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule, routes } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { HttpClientModule } from '@angular/common/http';
import { InitComponent } from './Pages/init/init.component';
import { TaskComponent } from './Pages/task/task.component';
import { provideRouter, withComponentInputBinding } from '@angular/router';

@NgModule({
  declarations: [AppComponent, InitComponent, TaskComponent],
  imports: [BrowserModule, AppRoutingModule],
  providers: [
    provideAnimationsAsync(),
    provideRouter(routes, withComponentInputBinding()),
    importProvidersFrom(HttpClientModule),
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
