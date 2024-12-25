import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: "app-navigation",
  templateUrl: "./navigation.component.html",
})
export class NavigationComponent {
  /**
   *
   */
  constructor(private router: Router,private activatedRoute : ActivatedRoute) {}
  CustomRouter(route: string): void {
    var currentRoute = this.activatedRoute.snapshot.url.map((segment) => segment.path);
    if(route === currentRoute.toString()) return;
    this.router.navigate([route]);
  }
}
