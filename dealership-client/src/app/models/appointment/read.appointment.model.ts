import { ReadGarageModel } from "../garage/read.garage.model";
import { ReadOwnerModel } from "../owner/read.owner.model";
import { ReadVehicleModel } from "../vehicle/read.vehicle.model";

export interface ReadAppointmentModel {

    id : number,
    owner : ReadOwnerModel,
    vehicle : ReadVehicleModel,
    garage : ReadGarageModel,
    dateOfArrival : Date,
    mileage : number,
    diagnosis : string,
    dateOfPickup : Date,
    created : Date
}