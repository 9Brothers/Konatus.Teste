import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AtualizarModeloAeronaveComponent } from './atualizar-modelo-aeronave.component';

describe('AtualizarModeloAeronaveComponent', () => {
  let component: AtualizarModeloAeronaveComponent;
  let fixture: ComponentFixture<AtualizarModeloAeronaveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AtualizarModeloAeronaveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AtualizarModeloAeronaveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
