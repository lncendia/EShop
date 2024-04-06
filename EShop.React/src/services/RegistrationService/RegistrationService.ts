import {IRegistrationService} from "./IRegistrationService.ts";
import {AxiosInstance} from "axios";
import {Tokens} from "../Common/Models/Tokens.ts";
import {RegistrationInputModel, ConfirmEmailInputModel} from "./InputModels/RegistrationInputModels.ts";

export class RegistrationService implements IRegistrationService {

    // Сервис для отправки запросов по API
    private axiosInstance: AxiosInstance

    constructor(axiosInstance: AxiosInstance) {
        this.axiosInstance = axiosInstance;
    }

    async registration(model: RegistrationInputModel): Promise<Tokens> {
        const response = await this.axiosInstance.post<Tokens>("auth/registration/Registration", model)
        return response.data
    }

    async confirmEmail(model: ConfirmEmailInputModel): Promise<void> {
        await this.axiosInstance.post("auth/registration/confirmEmail", model)
    }

}