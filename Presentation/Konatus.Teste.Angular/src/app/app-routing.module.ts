import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AtualizarAeronaveComponent } from './aeronave/atualizar-aeronave/atualizar-aeronave.component';
import { CadastroAeronaveComponent } from './aeronave/cadastro-aeronave/cadastro-aeronave.component';
import { HomeComponent } from './home/home.component';
import { AtualizarModeloAeronaveComponent } from './modelo-aeronave/atualizar-modelo-aeronave/atualizar-modelo-aeronave.component';
import { CadastroModeloAeronaveComponent } from './modelo-aeronave/cadastro-modelo-aeronave/cadastro-modelo-aeronave.component';


const routes: Routes = [
  // * Home
  { path: '', component: HomeComponent},
  
  // * Aircraft
  { path: 'aircraft/register', component: CadastroAeronaveComponent },
  { path: 'aircraft/update/:prefix', component: AtualizarAeronaveComponent },

  // * Aircraft Model
  { path: 'aircraft-model/register', component: CadastroModeloAeronaveComponent },
  { path: 'aircraft-model/update/:code', component: AtualizarModeloAeronaveComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }