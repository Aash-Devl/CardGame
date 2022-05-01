import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Card } from 'src/app/shared/models/card.model';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {

  @Input() public card!: Card;
  @Output() CardSlectedEvent = new EventEmitter<string>();

  public isSelected:boolean = false;
  constructor() { }

  ngOnInit(): void {
  }

  setColor(value:any){
    this.CardSlectedEvent.emit(value);
    if(this.isSelected){
      this.isSelected=false;
    }else{
      this.isSelected=true;
    }
  }
}
