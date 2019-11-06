import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})

export class AppComponent  implements OnInit  {
  securityGroups: object[];
  constructor() { }
  title = 'hartige-samaritaan-ui';

  ngOnInit(): void { }
  delay(ms: number) {
    return new Promise( resolve => setTimeout(resolve, ms) );
  }
}
