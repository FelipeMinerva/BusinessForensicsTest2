import { HttpClient } from '@angular/common/http';
import { ThrowStmt } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from 'src/environments/environment';
import { Animal } from '../models/Animal';

@Injectable({
  providedIn: 'root',
})
export class AnimalService {
  constructor(private httpService: HttpClient) {}

  public getAll(): Observable<Animal[]> {
    return this.httpService.get<Animal[]>(`/Animal/GetAll`);
  }

  public getByFamily(family: string): Observable<Animal[]> {
    return this.httpService.get<Animal[]>(`/Animal/GetByFamily/${family}`);
  }

  public addAnimal(animal: string): Observable<Animal> {
    return this.httpService.get<Animal>(`/Animal/Add/${animal.toLowerCase()}`);
  }

  public getDangerous(): Observable<Animal[]>{
    return this.httpService.get<Animal[]>(`/Animal/GetDangerous`);
  }
}
