import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AtualizarAeronaveComponent } from './atualizar-aeronave.component';

describe('AtualizarAeronaveComponent', () => {
  let component: AtualizarAeronaveComponent;
  let fixture: ComponentFixture<AtualizarAeronaveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AtualizarAeronaveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AtualizarAeronaveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
