import {Tokens} from "../Common/Models/Tokens.ts";
import {ConfirmEmailInputModel, RegistrationInputModel} from "./InputModels/RegistrationInputModels.ts";

export interface IRegistrationService {

    registration(model: RegistrationInputModel): Promise<Tokens>;

    confirmEmail(model: ConfirmEmailInputModel): Promise<void>;
}