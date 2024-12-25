import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { JssModule } from '@sitecore-jss/sitecore-jss-angular';
import { ExchangeRatesAndCurrenciesComponent } from './exchange-rates-and-currencies.component';

describe('ExchangeRatesAndCurrenciesComponent', () => {
  let component: ExchangeRatesAndCurrenciesComponent;
  let fixture: ComponentFixture<ExchangeRatesAndCurrenciesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [ JssModule.forRoot() ],
      declarations: [ ExchangeRatesAndCurrenciesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExchangeRatesAndCurrenciesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
