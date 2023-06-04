import { HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Restaurant } from 'src/app/Models/restaurant.model';
import { CategoryService } from 'src/app/Services/category.service';
import { MenuItemService } from 'src/app/Services/menu-item.service';
import { RestuarantService } from 'src/app/Services/restuarant.service';

@Component({
  selector: 'app-admin-dashbord-menue',
  templateUrl: './admin-dashbord-menue.component.html',
  styleUrls: ['./admin-dashbord-menue.component.css']
})
export class AdminDashbordMenueComponent {
  items:any;
  Category:any;
  cate:any;
  ID:any;
  itemdetails:any;
  file:any;
  myValidations!: FormGroup;
  addRestaurantValidations!: FormGroup;
  resAdminID="cdf78d74-1912-4444-99f2-b3fd9e91f38e";
  constructor(private fb : FormBuilder,public route: Router,public service:MenuItemService,public CategorieService:CategoryService,myRoute:ActivatedRoute,private restuarantService:RestuarantService){
    this.ID = myRoute.snapshot.params["itemID"];
  }
  header = new HttpHeaders({
    'Content-Type': 'multipart/form-data',
    'Accept': 'application/json'
   });
  ngOnInit(): void {
this.GetAllMenuItems()
    this.GetItemByID(this.ID);
    this.GetAllCategories();

    this.myValidations = this.fb.group({
      title:['',[Validators.maxLength(50),Validators.required,Validators.pattern(/^[a-zA-Z\s]*$/)]],
      price:['',[Validators.required,Validators.pattern(/^[0-9]+$/)]],
      size:['',[Validators.required,Validators.pattern(/^[MmLlSs]+$/)]],
      desc:['',[Validators.required]],
      img:['',[Validators.required]],
    });
    this.addRestaurantValidations = this.fb.group({
      Location:['',[Validators.required]],
      Name:['',[Validators.required,Validators.maxLength(50)]],
      Description:['',[Validators.required,]],
      EmailAddress:['',[Validators.required,Validators.email]],
      phoneNum:['',[Validators.required,Validators.maxLength(11)]],
      //ResAdminID:['',[Validators.required]],
      PosterFile:[null,Validators.required],
      BannearFile:[null,Validators.required]
    })
  }
  GetAllMenuItems(){
    this.service.GetAllMenuItem().subscribe({
      next:(data)=>{this.items=data;console.log(data);},
      error:(err)=>{console.log(err)}

    })
  }


  Additem (name:any,price:any,description:any,size:any,IsTop:any,resturantID:any,offer:any,categoryID:any){
    if(this.myValidations.valid){
      const formData = new FormData();
      formData.append('Name',name);
      formData.append('price',price);
      formData.append('Description',description);
      formData.append('size',size);
      if(IsTop == 'on'){
        formData.append('IsTopItem','true');

      }
      formData.append('IsTopItem','false');
      formData.append('ResturantID',resturantID);
      if(offer == 'on'){
        formData.append('offer','true');

      }

      formData.append('CategoryID',categoryID);
      formData.append('PhotoFile',this.file);


console.log({IsTop});
    this.service.Additem(formData,this.header).subscribe( {next:()=>{this.GetAllMenuItems();}} )

    this.route.navigateByUrl("/Adminmenu");

    }else{
      this.validateAllFormFields(this.myValidations);
    }
  }
  restaurantModel: Restaurant=new Restaurant();

  AddRestaurant (){
    console.log(this.restaurantModel)
    this.restaurantModel.ResAdminID=this.resAdminID;
    if(this.addRestaurantValidations.valid){
      const formData = new FormData();
      formData.append('Name',this.restaurantModel.Name);
      formData.append('Location',this.restaurantModel.Location);
      formData.append('EmailAddress',this.restaurantModel.EmailAddress);
      formData.append('phoneNum',this.restaurantModel.phoneNum);
      formData.append('Description',this.restaurantModel.Description);
      formData.append('ResAdminID',this.restaurantModel.ResAdminID);
     formData.append('BannearFile',this.restaurantModel.BannearFile);
     formData.append('PosterFile',this.restaurantModel.PosterFile);
   this.restuarantService.AddRestaurant(formData,this.header).subscribe( {
    next:()=>{alert("Restaurant added successfully")},
    error:(err:HttpErrorResponse)=>{console.log(err.error)},
    complete:()=>{}
   } )
   // this.route.navigateByUrl("/Adminmenu");
    }else{
      console.log("error")
      this.validateAllFormFields(this.addRestaurantValidations);
    }
  }
  get NameValid(){
    return this.myValidations.controls["title"].valid;
  }

  get NameExist(){
    return this.myValidations.controls["title"].value;
  }


  GetItemByID(id:any){
    this.service.GetItemById(id).subscribe({
      next:(data)=>{this.itemdetails=data},
      error:(err)=>{console.log(err)}

    })

  }
  Delete(id:any,row:any){
    this.service.Delete(id).subscribe();
    row.remove();
  }
  GetAllCategories(){
    this.CategorieService.GetAllCategories().subscribe({
      next:(data)=>{this.Category=data;console.log(data);},
      error:(err)=>{console.log(err)}
    })
  }

  UploadFile(event:any){
    this.file = event.target.files[0];
    console.log(this.file);
  }

  UploadPoster(event:any)
  {
    this.restaurantModel.PosterFile=event.target.files[0];
    console.log(this.restaurantModel.PosterFile);

  }
  UploadBanner(event:any){
    this.restaurantModel.BannearFile=event.target.files[0];
    console.log(this.restaurantModel.BannearFile);
  }
  private validateAllFormFields(formGroup: FormGroup){
    Object.keys(formGroup.controls).forEach(field =>{
      const control = formGroup.get(field);
      if(control instanceof FormControl){
        control.markAsDirty({onlySelf: true});
      }else if ( control instanceof FormGroup){
        this.validateAllFormFields(control);
      }
    })
  }

  //Add Restaurant

}
