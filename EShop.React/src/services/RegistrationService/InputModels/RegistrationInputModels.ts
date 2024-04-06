export interface ConfirmEmailInputModel {
    userId: string;
    code: string;
}

export interface RegistrationInputModel {
    email: string;
    password: string;
    username: string;
    confirmUrl: string;
}