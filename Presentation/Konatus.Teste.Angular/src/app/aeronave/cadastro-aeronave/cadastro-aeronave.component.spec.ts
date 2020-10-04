import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroAeronaveComponent } from './cadastro-aeronave.component';

describe('CadastroAeronaveComponent', () => {
  let component: CadastroAeronaveComponent;
  let fixture: ComponentFixture<CadastroAeronaveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastroAeronaveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroAeronaveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
