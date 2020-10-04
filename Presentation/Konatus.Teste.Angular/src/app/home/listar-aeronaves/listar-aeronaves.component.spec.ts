import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarAeronavesComponent } from './listar-aeronaves.component';

describe('ListarAeronavesComponent', () => {
  let component: ListarAeronavesComponent;
  let fixture: ComponentFixture<ListarAeronavesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListarAeronavesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListarAeronavesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
