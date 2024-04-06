export interface LoginInputModel {
    email: string;
    password: string;
}

export interface NewPasswordInputModel {
    newPassword: string;
    email: string;
    code: string;
}

export interface RecoverPasswordInputModel {
    email: string;
    resetUrl: string;
}