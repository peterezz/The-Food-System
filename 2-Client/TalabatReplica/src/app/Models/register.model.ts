export class Register {
    firstName:string|null="";
    lastName: string|null="";
    username:string|null="";
    email: string|null="";
    password: string|null="";
    AdminCheck:boolean|null=false
    Confirmation:boolean|null=true


    constructor(firstName:string|null ,lastName:string|null, username:string|null, email:string|null, password: string|null, AdminCheck:boolean|null,Confirmation:boolean|null)
    {
        this.firstName=firstName;
        this.lastName=lastName;
        this.username=username;
        this.email=email;
        this.password=password;
        this.AdminCheck=AdminCheck;
        this.Confirmation=true

    }

}
