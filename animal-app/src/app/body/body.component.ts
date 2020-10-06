import { Component, Input, OnInit } from '@angular/core';
import { Animal } from '../models/Animal';
import { AnimalService } from '../services/animal.service';

@Component({
  selector: 'app-body',
  templateUrl: './body.component.html',
  styleUrls: ['./body.component.css'],
})
export class BodyComponent implements OnInit {
  @Input() animals: Animal[];

  ngOnInit() {}

  public removeAnimal(animal: Animal) {
    const index = this.animals.indexOf(animal);
    this.animals.splice(index, 1);
  }
}
