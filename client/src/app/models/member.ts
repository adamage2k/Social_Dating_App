import { Photo } from './photo'

export interface Member {
    id: number;
    age: number;
    localization: string;
    username: string;
    knownAs: string;
    email: string;
    firstName: string;
    lastName: string;
    photo: string;
}