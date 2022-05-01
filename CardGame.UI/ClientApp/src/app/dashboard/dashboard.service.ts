import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Card } from '../shared/models/card.model';
import { map } from 'rxjs/operators';

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  
@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  constructor(private http: HttpClient, private router: Router) {
  }

  AllCards() {
    return this.http.get<any>(environment.apiURL + `/Card/AllCards`, httpOptions)
        .pipe(map(response => {
            return response;
        }));
    }

  SortCards(input: any) {
    return this.http.post<any>(environment.apiURL + `/Card/SortCards`, { input }, httpOptions)
        .pipe(map(response => {
            return response;
        }));
}
}