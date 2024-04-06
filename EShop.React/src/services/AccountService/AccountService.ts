import {IAccountService} from "./IAccountService.ts";
import {AxiosInstance} from "axios";
import {Tokens} from "../Common/Models/Tokens.ts";
import {LoginInputModel, NewPasswordInputModel, RecoverPasswordInputModel} from "./InputModels/AccountInputModels.ts";

export class AccountService implements IAccountService {

    // Сервис для отправки запросов по API
    private axiosInstance: AxiosInstance

    constructor(axiosInstance: AxiosInstance) {
        this.axiosInstance = axiosInstance;
    }

    async token(model: LoginInputModel): Promise<Tokens> {
        const response = await this.axiosInstance.post<Tokens>("auth/account/token", model)
        return response.data;
    }

    async refreshToken(refreshToken: string): Promise<Tokens> {
        const response = await this.axiosInstance.get<Tokens>("auth/account/refreshToken", {params: {refreshToken}})
        return response.data;
    }

    async recoverPassword(model: RecoverPasswordInputModel): Promise<void> {
        await this.axiosInstance.post<Tokens>("auth/account/recoverPassword", model)
    }

    async newPassword(model: NewPasswordInputModel): Promise<void> {
        await this.axiosInstance.post<Tokens>("auth/account/newPassword", model)
    }

}