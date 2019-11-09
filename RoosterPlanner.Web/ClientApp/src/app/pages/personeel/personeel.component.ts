import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-personeel',
  templateUrl: './personeel.component.html',
  styleUrls: ['./personeel.component.less']
})
export class PersoneelComponent implements OnInit {
  displayedColumns = ['Naam', 'Recent', 'Beschikbaarheid', 'Geroosterd','Certificaten'];
  dataSource = ELEMENT_DATA;
  constructor() { }

  ngOnInit() {
  }

}
export interface PeriodicElement {
  Naam : string;
  Recent: string;
  Beschikbaarheid: number;
  Geroosterd: number;
  Certificaten: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {Naam: 'Adriaan', Recent: '19-01-1999', Beschikbaarheid: 6, Geroosterd: 3, Certificaten: 'Fiets'},
  {Naam: 'Adriaan', Recent: '19-01-1999', Beschikbaarheid: 6, Geroosterd: 3, Certificaten: 'Fiets'},
  {Naam: 'Adriaan', Recent: '19-01-1999', Beschikbaarheid: 6, Geroosterd: 3, Certificaten: 'Fiets'},
  {Naam: 'Adriaan', Recent: '19-01-1999', Beschikbaarheid: 6, Geroosterd: 3, Certificaten: 'Fiets'},
  {Naam: 'Adriaan', Recent: '19-01-1999', Beschikbaarheid: 6, Geroosterd: 3, Certificaten: 'Fiets'},
  {Naam: 'Adriaan', Recent: '19-01-1999', Beschikbaarheid: 6, Geroosterd: 3, Certificaten: 'Fiets'},
  {Naam: 'Adriaan', Recent: '19-01-1999', Beschikbaarheid: 6, Geroosterd: 3, Certificaten: 'Fiets'},
  {Naam: 'Adriaan', Recent: '19-01-1999', Beschikbaarheid: 6, Geroosterd: 3, Certificaten: 'Fiets'},
  {Naam: 'Adriaan', Recent: '19-01-1999', Beschikbaarheid: 6, Geroosterd: 3, Certificaten: 'Fiets'},
  {Naam: 'Adriaan', Recent: '19-01-1999', Beschikbaarheid: 6, Geroosterd: 3, Certificaten: 'Fiets'},
  {Naam: 'Adriaan', Recent: '19-01-1999', Beschikbaarheid: 6, Geroosterd: 3, Certificaten: 'Fiets'},
  {Naam: 'Adriaan', Recent: '19-01-1999', Beschikbaarheid: 6, Geroosterd: 3, Certificaten: 'Fiets'},
  {Naam: 'Adriaan', Recent: '19-01-1999', Beschikbaarheid: 6, Geroosterd: 3, Certificaten: 'Fiets'},
  {Naam: 'Adriaan', Recent: '19-01-1999', Beschikbaarheid: 6, Geroosterd: 3, Certificaten: 'Fiets'},
  {Naam: 'Adriaan', Recent: '19-01-1999', Beschikbaarheid: 6, Geroosterd: 3, Certificaten: 'Fiets'},
  {Naam: 'Adriaan', Recent: '19-01-1999', Beschikbaarheid: 6, Geroosterd: 3, Certificaten: 'Fiets'},
  {Naam: 'Adriaan', Recent: '19-01-1999', Beschikbaarheid: 6, Geroosterd: 3, Certificaten: 'Fiets'},
  {Naam: 'Adriaan', Recent: '19-01-1999', Beschikbaarheid: 6, Geroosterd: 3, Certificaten: 'Fiets'},
  {Naam: 'Adriaan', Recent: '19-01-1999', Beschikbaarheid: 6, Geroosterd: 3, Certificaten: 'Fiets'},
  {Naam: 'Adriaan', Recent: '19-01-1999', Beschikbaarheid: 6, Geroosterd: 3, Certificaten: 'Fiets'},

];