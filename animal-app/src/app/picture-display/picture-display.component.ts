import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Animal } from '../models/Animal';

@Component({
  selector: 'app-picture-display',
  templateUrl: './picture-display.component.html',
  styleUrls: ['./picture-display.component.css'],
})
export class PictureDisplayComponent implements OnInit {
  @Input() animal: Animal;
  @Output() removeAnimalEvent = new EventEmitter<Animal>();

  constructor() {}

  ngOnInit(): void {}

  public removeAnimal() {
    this.removeAnimalEvent.emit(this.animal);
  }
}
