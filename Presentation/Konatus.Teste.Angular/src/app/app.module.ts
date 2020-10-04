import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CadastroAeronaveComponent } from './aeronave/cadastro-aeronave/cadastro-aeronave.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";

// * Material Modules
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatAutocompleteModule } from "@angular/material/autocomplete";
import { CadastroModeloAeronaveComponent } from './modelo-aeronave/cadastro-modelo-aeronave/cadastro-modelo-aeronave.component';
import { MatDividerModule } from "@angular/material/divider";
import { ErrorStateMatcher, ShowOnDirtyErrorStateMatcher } from '@angular/material/core';
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { MatGridListModule } from "@angular/material/grid-list";
import { AtualizarModeloAeronaveComponent } from './modelo-aeronave/atualizar-modelo-aeronave/atualizar-modelo-aeronave.component';
import { AtualizarAeronaveComponent } from './aeronave/atualizar-aeronave/atualizar-aeronave.component';
import { MatSlideToggleModule } from "@angular/material/slide-toggle";
import { ListarAeronavesComponent } from './home/listar-aeronaves/listar-aeronaves.component';
import { MatTableModule } from "@angular/material/table";
import { MatPaginatorModule } from "@angular/material/paginator";
import { ListarModelosAeronavesComponent } from './home/listar-modelos-aeronaves/listar-modelos-aeronaves.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    CadastroAeronaveComponent,
    CadastroModeloAeronaveComponent,
    AtualizarModeloAeronaveComponent,
    AtualizarAeronaveComponent,
    ListarAeronavesComponent,
    ListarModelosAeronavesComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,

    // * Material
    MatCardModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatAutocompleteModule,
    MatDividerModule,
    MatSnackBarModule,
    MatGridListModule,
    MatSlideToggleModule,
    MatTableModule,
    MatPaginatorModule
  ],
  providers: [
    { provide: ErrorStateMatcher, useClass: ShowOnDirtyErrorStateMatcher }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }