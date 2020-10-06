import { Component, OnInit } from '@angular/core';
import { Animal } from './models/Animal';
import { AnimalService } from './services/animal.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  animals: Animal[];

  showingDangerous =false;

  constructor(private animalService: AnimalService) {}

  ngOnInit() {
    this.getAll();
  }

  public getAll() {
    this.animalService.getAll().subscribe((z) => (this.animals = z));
  }

  public addAnimal(animal: string): void {
    this.animalService
      .addAnimal(animal)
      .subscribe((z) => this.animals.splice(0, 0, z));
  }

  public filterDangerous(): void {
    if (!this.showingDangerous){
      this.animalService.getDangerous().subscribe((z) => (this.animals = z));
      this.showingDangerous = !this.showingDangerous;
    }
    else this.getAll();
  }
}
