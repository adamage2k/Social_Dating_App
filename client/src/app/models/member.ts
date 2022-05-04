import { Photo } from './photo'

export interface Member {
    id: number;
    age: number;
    knownAs: string;
    email: string;
    firstName: string;
    lastName: string;
    photo: string;
}