import { KeyValue } from "@angular/common";

export class AlgoParam {
    id: number;
    name: string;
    type: KeyValue<number, string>;
    isMandatory : boolean;
}