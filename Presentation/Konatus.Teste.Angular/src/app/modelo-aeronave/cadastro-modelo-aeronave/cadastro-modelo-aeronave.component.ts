import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AircraftModel } from 'src/entities/aircraft-model';
import { ajax } from "rxjs/ajax";
import { MatSnackBar } from "@angular/material/snack-bar";
import { environment } from 'src/environments/environment';
import { AircraftModelService } from 'src/app/services/aircraft-model.service';


@Component({
  selector: 'app-cadastro-modelo-aeronave',
  templateUrl: './cadastro-modelo-aeronave.component.html',
  styleUrls: ['./cadastro-modelo-aeronave.component.scss']
})
export class CadastroModeloAeronaveComponent implements OnInit {

  code = new FormControl('', [
    Validators.required,
    Validators.maxLength(4)
  ]);

  alternativeCode = new FormControl('', [
    Validators.required,
    Validators.maxLength(4)
  ]);

  maxDepartureWeight = new FormControl('', [
    Validators.required,
    Validators.min(0),
    Validators.max(999999),
  ]);

  maxLandingWeight = new FormControl('', [
    Validators.required,
    Validators.min(0),
    Validators.max(999999),
  ]);

  registerAircraftModelFormGroup = new FormGroup({
    code: this.code,
    alternativeCode: this.alternativeCode,
    maxDepartureWeight: this.maxDepartureWeight,
    maxLandingWeight: this.maxLandingWeight
  });

  constructor(private _aircraftModelService: AircraftModelService, private _router: Router, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
  }

  save() {

    if (this.registerAircraftModelFormGroup.valid) {
      let aircraftModel = new AircraftModel();
      aircraftModel.code = this.registerAircraftModelFormGroup.get('code').value;
      aircraftModel.alternativeCode = this.registerAircraftModelFormGroup.get('alternativeCode').value;
      aircraftModel.maxDepartureWeight = this.registerAircraftModelFormGroup.get('maxDepartureWeight').value;
      aircraftModel.maxLandingWeight = this.registerAircraftModelFormGroup.get('maxLandingWeight').value;

      this._aircraftModelService.add(aircraftModel)
        .then(() => this._router.navigateByUrl('/'))
        .catch(err => this._snackBar.open(err, null, { duration: 3000 }));
    }
  }

  back() {
    window.history.back();
  }

}
