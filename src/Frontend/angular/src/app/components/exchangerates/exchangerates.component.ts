import { Component, OnInit, Input, OnDestroy } from "@angular/core";
import { ComponentRendering } from "@sitecore-jss/sitecore-jss-angular";
import { JssContextService } from "../../jss-context.service";
import { TranslateService } from "@ngx-translate/core";
import { ApiService } from "../../Services/api.service";
import { SubSink } from "subsink";
import { environment } from "../../../environments/environment";
// import { JssState } from "../../JssState";
/* eslint-disable */
@Component({
  selector: "exchangerates",
  templateUrl: "./exchangerates.component.html",
  styleUrls: ["./exchangerates.component.css"],
})
export class ExchangeratesComponent implements OnInit, OnDestroy {
  @Input() rendering: ComponentRendering;
  constructor(
    private api: ApiService,
    private context: JssContextService,
    public translate: TranslateService
    // private jssState: JssState
  ) {}
  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
  urlBase: string;
  fields: any;
  currenciesInfo: any;
  private subs = new SubSink();
  ngOnInit() {
    this.urlBase = environment.sitecoreApiHost;
    this.fields = this.context.stateValue.sitecore.route.fields;
    this.subs.sink = this.api
      .Get(null, `api/Currencies/GetCurrencies?lang=${this.context.stateValue.language}`)
      .subscribe({
        next: (rows) => {
          this.currenciesInfo = rows;
        },
        error: (err) => {
          console.log(err);
        },
      });
  }

  PrintLang() {
    // console.log(this.jssState.language);
  
  }
}
