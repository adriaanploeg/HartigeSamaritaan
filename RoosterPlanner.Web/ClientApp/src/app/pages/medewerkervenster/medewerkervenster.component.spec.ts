import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MedewerkervensterComponent } from './medewerkervenster.component';

describe('MedewerkervensterComponent', () => {
  let component: MedewerkervensterComponent;
  let fixture: ComponentFixture<MedewerkervensterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MedewerkervensterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MedewerkervensterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
