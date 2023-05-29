import { HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { CategoryService } from 'src/app/Services/category.service';
import { MenuItemService } from 'src/app/Services/menu-item.service';

@Component({
  selector: 'app-admin-dashbord-menue',
  templateUrl: './admin-dashbord-menue.component.html',
  styleUrls: ['./admin-dashbord-menue.component.css']
})
export class AdminDashbordMenueComponent {
  items:any;
  Category:any;
  ID:any;
  itemdetails:any;
  file:any;
  myValidations!: FormGroup;
  constructor(private fb : FormBuilder,public route: Router,public service:MenuItemService,public CategorieService:CategoryService,myRoute:ActivatedRoute){
    this.ID = myRoute.snapshot.params["itemID"];
  }
  ngOnInit(): void {
    this.service.GetAllMenuItem().subscribe({
      next:(data)=>{this.items=data;console.log(data);},
      error:(err)=>{console.log(err)}

    })
    this.GetItemByID(this.ID);
    this.GetAllCategories();
    this.myValidations = this.fb.group({
      title:['',[Validators.maxLength(50),Validators.required]],
      price:['',[Validators.required]],
      size:['',[Validators.required]],
selectedOption:['',[Validators.required]],
      desc:['',[Validators.required]],
      img:['',[Validators.required]],
    })
  }
  Additem (name:any,price:any,description:any,size:any,resturantID:any,categoryID:any,categoryName:any){
    if(this.myValidations.valid){
      const formData = new FormData();
      formData.append('Name',name);
      formData.append('price',price);
      formData.append('Description',description);
      formData.append('size',size);
      formData.append('ResturantID',resturantID);
      formData.append('CategoryID',categoryID);
      formData.append('CategoryName',categoryName);
      formData.append('PhotoFile',this.file);
       const header = new HttpHeaders({
        'Content-Type': 'multipart/form-data',
        'Accept': 'application/json'
       });
      console.log(formData)
    this.service.Additem(formData,header).subscribe(  )
    this.route.navigateByUrl("/Adminmenu");
    }else{
      this.validateAllFormFields(this.myValidations);
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
}
