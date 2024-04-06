import {Tokens} from "../Common/Models/Tokens.ts";
import {LoginInputModel, NewPasswordInputModel, RecoverPasswordInputModel} from "./InputModels/AccountInputModels.ts";

export interface IAccountService {

    token(model: LoginInputModel): Promise<Tokens>;

    refreshToken(refreshToken: string): Promise<Tokens>;

    recoverPassword(model: RecoverPasswordInputModel): Promise<void>;

    newPassword(model: NewPasswordInputModel): Promise<void>;
}