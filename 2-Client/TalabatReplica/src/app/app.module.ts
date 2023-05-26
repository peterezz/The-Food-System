import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './Components/Layout/header/header.component';
import { FooterComponent } from './Components/Layout/footer/footer.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RestaurantComponent } from './Components/restaurant/restaurant.component';
import { LoginComponent } from './Components/login/login.component';
import { ErrorComponent } from './Components/error/error.component';
import { CheckOutComponent } from './Components/check-out/check-out.component';
import { AllResturantsComponent } from './Components/all-resturants/all-resturants.component';
import { AllResturantsItemsComponent } from './Components/all-resturants-items/all-resturants-items.component';
import { SingleproductComponent } from './Components/singleproduct/singleproduct.component';
import { CartComponent } from './Components/cart/cart.component';
import { PaymentComponent } from './Components/payment/payment.component';
import { ForgotPasswordComponent } from './Components/forgot-password/forgot-password.component';
import { SetnewpasswordComponent } from './Components/setnewpassword/setnewpassword.component';
import { ContactComponent } from './Components/contact/contact.component';
import { CategoryItemsComponent } from './Components/category-items/category-items.component';
import { RouterLink } from '@angular/router';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    RestaurantComponent,
    LoginComponent,
    ErrorComponent,
    CheckOutComponent,
    AllResturantsComponent,
    AllResturantsItemsComponent,
    SingleproductComponent,
    CartComponent,
    PaymentComponent,
    ForgotPasswordComponent,
    SetnewpasswordComponent,
    ContactComponent,
    CategoryItemsComponent,



  ],
  imports: [

    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterLink

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
