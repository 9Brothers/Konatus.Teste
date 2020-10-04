import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { ajax } from 'rxjs/ajax';
import { AircraftModelService } from 'src/app/services/aircraft-model.service';
import { AircraftModel } from 'src/entities/aircraft-model';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-atualizar-modelo-aeronave',
  templateUrl: './atualizar-modelo-aeronave.component.html',
  styleUrls: ['./atualizar-modelo-aeronave.component.scss']
})
export class AtualizarModeloAeronaveComponent implements OnInit {

  codeParam: string = '';

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

  active = new FormControl();

  updateAircraftModelFormGroup = new FormGroup({
    code: this.code,
    alternativeCode: this.alternativeCode,
    maxDepartureWeight: this.maxDepartureWeight,
    maxLandingWeight: this.maxLandingWeight,
  });

  constructor(private _aircraftModelService: AircraftModelService, private _router: Router, private _route: ActivatedRoute, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this._route.params.subscribe(params => {

      this.codeParam = params['code'];

      this._aircraftModelService.get(this.codeParam)
        .then(response => {
          let aircraftModel = response[0];

          this.code.setValue(aircraftModel.code);
          this.alternativeCode.setValue(aircraftModel.alternativeCode);
          this.maxDepartureWeight.setValue(aircraftModel.maxDepartureWeight);
          this.maxLandingWeight.setValue(aircraftModel.maxLandingWeight);
        })
        .catch(err => {
          console.error(err);

          this._snackBar.open('The aircraft model could not be loaded.', '', { duration: 3000 })
        });
    });
  }

  save() {

    if (this.updateAircraftModelFormGroup.valid) {
      let aircraftModel = new AircraftModel();
      aircraftModel.code = this.updateAircraftModelFormGroup.get('code').value;
      aircraftModel.alternativeCode = this.updateAircraftModelFormGroup.get('alternativeCode').value;
      aircraftModel.maxDepartureWeight = this.updateAircraftModelFormGroup.get('maxDepartureWeight').value;
      aircraftModel.maxLandingWeight = this.updateAircraftModelFormGroup.get('maxLandingWeight').value;

      this._aircraftModelService.update(aircraftModel)
        .then(() => this._router.navigateByUrl('/'))
        .catch(this.catch);
    }
  }

  delete() {
    this._aircraftModelService.delete(this.codeParam)
      .then(() => this._router.navigateByUrl('/'))
      .catch(this.catch);
  }

  back() {
    window.history.back();
  }

  catch = (err) => {
    console.error(err)

    this._snackBar.open('The aircraft model could not be updated', null, { duration: 3000 })
  }

}
