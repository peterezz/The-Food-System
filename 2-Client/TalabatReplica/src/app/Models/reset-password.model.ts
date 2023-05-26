export class ResetPassword {
    userEmailAddress:string = "";
    newPassword:string|null = "";
    confirmPassword:string |null = "";
    token:string = "";
    constructor(userEmailAddress:string, newPassword:string|null,confirmPassword:string|null,token:string){
        this.userEmailAddress = userEmailAddress;
        this.newPassword = newPassword;
        this.confirmPassword = confirmPassword;
        this.token = token;
    }
}
