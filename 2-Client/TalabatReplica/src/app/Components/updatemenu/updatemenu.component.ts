import { HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryService } from 'src/app/Services/category.service';
import { MenuItemService } from 'src/app/Services/menu-item.service';

@Component({
  selector: 'app-updatemenu',
  templateUrl: './updatemenu.component.html',
  styleUrls: ['./updatemenu.component.css']
})
export class UpdatemenuComponent  {
  ID:any;
  itemdetails:any;
  Category:any;
  ResID:any;
  categories:any;
  selectedFile:any;
  myValidations!: FormGroup;
 // noFileChosen:any;
  constructor(private fb : FormBuilder,public service:MenuItemService,myRoute:ActivatedRoute,public CategorieService:CategoryService,public route:Router){
    this.ID = myRoute.snapshot.params["itemID"];
  }
  ngOnInit(): void {
    this.service.GetItemById(this.ID).subscribe({
      next:(data)=>{this.itemdetails=data;console.log(this.itemdetails);},
      error:(err)=>{console.log(err)}


    })
    this.GetAllCategories();
  //this.GetAllCategoriesByResID(this.ResID);

  this.myValidations = this.fb.group({
    title:['',[Validators.maxLength(50),Validators.required]],
    price:['',[Validators.required]],
    size:['',[Validators.required]],
    category:['',[Validators.required]],
    desc:['',[Validators.required]],
    img:['',[Validators.required]],
  })
  }
  updateItem(itemID:any,name:any,price:any,description:any,size:any,resturantID:any,categoryID:any){
    const formData = new FormData();
    formData.append('ItemID',itemID);
    formData.append('Name',name);
    formData.append('price',price);
    formData.append('Description',description);
    formData.append('size',size);
    formData.append('ResturantID',resturantID);
    formData.append('CategoryID',categoryID);
    formData.append('PhotoFile',this.selectedFile);
     const header = new HttpHeaders({
      'Content-Type': 'multipart/form-data',
      'Accept': 'application/json'
     });
    console.log({itemID,name,price,description,size,resturantID,categoryID},+this.ID);
    this.service.updateItem(formData,+this.ID,header).subscribe();
    this.route.navigateByUrl("/Adminmenu");

  }
  GetAllCategories(){
    this.CategorieService.GetAllCategories().subscribe({
      next:(data)=>{this.Category=data;console.log(data);},
      error:(err)=>{console.log(err)}
    })
  }
//   GetAllCategoriesByResID(ResID:any){
//   this.service.GetAllCategoriesByResID(this.ResID).subscribe({
//     next:(data)=>{
//       this.categories = data;
//       console.log(this.categories)
//     }
//   })
// }

SelectedFile(event: any) {
  this.selectedFile = event.target.files[0];
  console.log(this.selectedFile.name)

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
