import { Component, Inject } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import { JssContextService } from "../../jss-context.service";
import { Router } from "@angular/router";
import { ActivatedRoute } from "@angular/router";
import { DOCUMENT } from "@angular/common";
/* eslint-disable */

@Component({
  selector: "app-language-switcher",
  standalone: true,
  imports: [],
  templateUrl: "./language-switcher.component.html",
  styleUrl: "./language-switcher.component.css",
})
export class LanguageSwitcherComponent {
  LANG_REGEXP = /^\/([a-zA-Z]{2}(-[a-zA-Z]{2})?)/;
  // inject ngx-translate service to get translation state
  // (in this example, the current language)
  constructor(
    public translate: TranslateService,
    private jssService: JssContextService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    @Inject(DOCUMENT) private document: Document
  ) {}
  isEnLang: boolean;

  switchLanguage(event: Event) : void {
    const lang = (event.target as HTMLSelectElement).value;
    this.isEnLang = this.jssService.stateValue.language === "en";
    this.jssService.changeLanguage(lang);
    if (lang === "ar") this.document.documentElement.setAttribute("dir", "rtl");
    else this.document.documentElement.setAttribute("dir", "ltr");
    var currentRoute = this.activatedRoute.snapshot.url
      .map((segment) => segment.path)
      .join("/");
    this.router.navigate([currentRoute]);
  }
}
