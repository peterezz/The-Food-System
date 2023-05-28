import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RestaurantComponent } from './Components/restaurant/restaurant.component';
import { LoginComponent } from './Components/login/login.component';
import { ErrorComponent } from './Components/error/error.component';
import { CheckOutComponent } from './Components/check-out/check-out.component';
import { AllResturantsComponent } from './Components/all-resturants/all-resturants.component';
import { SingleproductComponent } from './Components/singleproduct/singleproduct.component';
import { CartComponent } from './Components/cart/cart.component';
import { PaymentComponent } from './Components/payment/payment.component';
import { AdminDashbordComponent } from './Components/admin-dashbord/admin-dashbord.component';
import { ForgotPasswordComponent } from './Components/forgot-password/forgot-password.component';
import { SetnewpasswordComponent } from './Components/setnewpassword/setnewpassword.component';
import { ContactComponent } from './Components/contact/contact.component';
import { CategoryItemsComponent } from './Components/category-items/category-items.component';
import { FilterbycatComponent } from './Components/filterbycat/filterbycat.component';

const routes: Routes = [
  {path:"", component: RestaurantComponent},
  {path:"ResProfile/:restaurantID", component: RestaurantComponent},
  {path:"category/:name", component: CategoryItemsComponent},
  {path:"login", component: LoginComponent},
  {path:"checkOut", component: CheckOutComponent},
  {path:"AllResturants", component: AllResturantsComponent},
  {path:"singleProduct", component: SingleproductComponent},
  {path:"cart", component: CartComponent },
  {path:"pay", component: PaymentComponent },
  {path:"Admin", component: AdminDashbordComponent },
  {path:"forgetpassword", component: ForgotPasswordComponent },
  {path:"setnewpassword", component: SetnewpasswordComponent },
  {path:"contactus", component: ContactComponent },
  {path:"category", component: CategoryItemsComponent},
  {path:"Filterbycat", component: FilterbycatComponent},
  {path:"**", component: ErrorComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
