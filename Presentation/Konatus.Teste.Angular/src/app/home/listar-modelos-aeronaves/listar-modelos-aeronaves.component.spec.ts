import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarModelosAeronavesComponent } from './listar-modelos-aeronaves.component';

describe('ListarModelosAeronavesComponent', () => {
  let component: ListarModelosAeronavesComponent;
  let fixture: ComponentFixture<ListarModelosAeronavesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListarModelosAeronavesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListarModelosAeronavesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
