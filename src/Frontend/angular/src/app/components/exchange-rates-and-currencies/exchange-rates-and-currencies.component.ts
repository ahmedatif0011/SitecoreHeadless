import { Component, OnInit, Input } from '@angular/core';
import { ComponentRendering } from '@sitecore-jss/sitecore-jss-angular';
/* eslint-disable */
@Component({
  selector: 'exchange-rates-and-currencies',
  templateUrl: './exchange-rates-and-currencies.component.html',
  styleUrls: ['./exchange-rates-and-currencies.component.css']
})
export class ExchangeRatesAndCurrenciesComponent implements OnInit {
  @Input() rendering: ComponentRendering;

  constructor() { }
  
  ngOnInit() {
  debugger;
    // remove this after implementation is done
    console.log('ExchangeRatesAndCurrencies component initialized with component data', this.rendering);
  }
}
