import { animate, keyframes, query, stagger, style, transition, trigger } from '@angular/animations';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Subscription } from 'rxjs/internal/Subscription';
import { Card } from 'src/app/shared/models/card.model';
import { DashboardService } from '../dashboard.service';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.scss'],
  animations: [
    trigger('cardAnimation', [
      transition('* => *', [
        query(':enter', style({ opacity: 0 }), { optional: true }),
        query(':enter', stagger('100ms', [
          animate('.75s cubic-bezier(0.215, 0.61, 0.355, 1)',
            keyframes([
              style({ opacity: 0, transform: 'scale3d(0.3, 0.3, 0.3)', offset: 0 }),
              style({ opacity: 0.2, transform: 'scale3d(1.1, 1.1, 1.1)', offset: 0.2 }),
              style({ opacity: 0.4, transform: 'scale3d(0.9, 0.9, 0.9)', offset: 0.4 }),
              style({ opacity: 0.6, transform: 'scale3d(1.03, 1.03, 1.03)', offset: 0.6 }),
              style({ opacity: 0.8, transform: 'scale3d(0.97, 0.97, 0.97)', offset: 0.8 }),
              style({ opacity: 1, transform: 'scale3d(1, 1, 1)', offset: 1.0 }),
            ]))]), { optional: true })
      ])
    ])

  ]
})
export class CardsComponent implements OnInit, OnDestroy {
  form: FormGroup;

  public cards: Card[] = [];
  public cardsUnsorted: Card[] = [];
  public cardsSorted: Card[] = [];

  private subscription: Subscription = new Subscription();

  constructor(fb: FormBuilder, public dashboardService: DashboardService) {
    this.form = fb.group({
      cardsSorted: new FormControl(''),
      cardsUnsorted: new FormControl('')
    });
   }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  ngOnInit(): void {
    this.initialize();
  }

  private initialize(): void {
    this.cards = [];
    this.subscription.add(this.dashboardService.AllCards().subscribe(
      suc => {
        this.cards = suc;
      },
      err => {
        console.log(err);
      }
    ));
  }

  Sort(){
    this.cardsSorted = [];
    this.subscription.add(this.dashboardService.SortCards(this.cardsUnsorted).subscribe(
      suc => {
        this.cardsSorted = suc;
        this.form.controls['cardsSorted'].setValue(suc);
      },
      err => {
        console.log(err);
      }
    ));
  }

  Shuffle(){
    for (let i = this.cards.length - 1; i > 0; i--) {
      const j = Math.floor(Math.random() * (i + 1));
      [this.cards[i], this.cards[j]] = [this.cards[j], this.cards[i]];
  }
  return this.cards;
  }

  Reset(){
    this.cardsSorted = [];
    this.cardsUnsorted = [];
    this.form.reset();
    this.initialize();
  }

  CardSelected(event:any){
    const startIndex = this.cardsUnsorted.indexOf(event);
    const deleteCount = 1;

    if (startIndex !== -1) {
      this.cardsUnsorted.splice(startIndex, deleteCount);
    }else{
      this.cardsUnsorted.push(event);
    }
    this.form.controls['cardsUnsorted'].setValue(this.cardsUnsorted);
  }
}
