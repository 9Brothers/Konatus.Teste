import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroModeloAeronaveComponent } from './cadastro-modelo-aeronave.component';

describe('CadastroModeloAeronaveComponent', () => {
  let component: CadastroModeloAeronaveComponent;
  let fixture: ComponentFixture<CadastroModeloAeronaveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastroModeloAeronaveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroModeloAeronaveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
