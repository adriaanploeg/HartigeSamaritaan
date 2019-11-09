import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PersoneelComponent } from './personeel.component';

describe('PersoneelComponent', () => {
  let component: PersoneelComponent;
  let fixture: ComponentFixture<PersoneelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersoneelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersoneelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
