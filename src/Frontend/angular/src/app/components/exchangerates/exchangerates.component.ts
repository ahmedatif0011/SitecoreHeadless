import { Component, OnInit, Input, OnDestroy } from "@angular/core";
import { ComponentRendering } from "@sitecore-jss/sitecore-jss-angular";
import { JssContextService } from "../../jss-context.service";
import { TranslateService } from "@ngx-translate/core";
import { ApiService } from "../../Services/api.service";
import { SubSink } from "subsink";
import { environment } from "../../../environments/environment";
import { APIServiceInterface } from "../../Interfaces/apiservice-interface";
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
  ) // private jssState: JssState
  {}
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

    const GetCurrencies: APIServiceInterface = {
      url: `api/Currencies/GetCurrencies?lang=${this.context.stateValue.language}`,
      URLBase: null,
      headersObj: null,
      paramsObj: null,
      body: null,
      isFormData: false,
    };
    this.subs.sink = this.api.Get(GetCurrencies).subscribe({
      next: (rows) => {
        this.currenciesInfo = rows;
      },
      error: (err) => {
        console.log(err);
      },
    });

    const Children: APIServiceInterface = {
      url: "Api/v1/SitecoreServices/Children",
      URLBase: "https://localhost:44342/",
      headersObj: null,
      paramsObj: {
        language: this.context.stateValue.language,
        fields:
          "currency code,name,flag,notes buy rate,notes sell rate,transfere buy rate,transfere sell rate",
        ItemId: "{CC3FD663-3AAB-4134-83CB-A849BF58800A}",
      },
      body: null,
      isFormData: false,
    };
    this.api.Get(Children).subscribe({
      next: (dta) => {
        console.log(dta);
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
