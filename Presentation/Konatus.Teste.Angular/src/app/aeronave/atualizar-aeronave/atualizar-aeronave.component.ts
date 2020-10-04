import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, ActivationEnd, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ajax } from 'rxjs/ajax';
import { startWith, map } from 'rxjs/operators';
import { Aircraft } from 'src/entities/aircraft';
import { AircraftModel } from 'src/entities/aircraft-model';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-atualizar-aeronave',
  templateUrl: './atualizar-aeronave.component.html',
  styleUrls: ['./atualizar-aeronave.component.scss']
})
export class AtualizarAeronaveComponent implements OnInit {

  aircraftModels: AircraftModel[] = [];
  filteredOptions: Observable<AircraftModel[]>;

  prefix = new FormControl('', [
    Validators.required,
    Validators.maxLength(6)
  ]);

  aircraftModel = new FormControl('', [
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

  active = new FormControl(false);

  registerAircraftFormGroup = new FormGroup({
    prefix: this.prefix,
    aircraftModel: this.aircraftModel,
    maxDepartureWeight: this.maxDepartureWeight,
    maxLandingWeight: this.maxLandingWeight,
    active: this.active
  });

  constructor(private _router: Router, private _route: ActivatedRoute, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {

    let prefix: string;

    this._route.params.subscribe(params => {
      prefix = params['prefix'];
    });

    ajax({
      url: `${environment.baseUrl}/ModeloAeronave/All`,
      method: 'GET',
      headers: { 'Accept': 'application/json' }
    })
    .toPromise()
    .then(response => {
      this.aircraftModels = response.response;

      this.filteredOptions = this.aircraftModel.valueChanges.pipe(
        startWith(''),
        map(value => this._filter(value))
      );

      return ajax({
        url: `${environment.baseUrl}/Aeronave?prefix=${prefix}`,
        method: 'GET',
        headers: { 'Accept': 'application/json' }
      })
      .toPromise();
    })
    .then(response => {

      let aeronave = response.response[0] as Aircraft;

      this.prefix.setValue(aeronave.prefix);
      this.aircraftModel.setValue(aeronave.aircraftModel);
      this.maxDepartureWeight.setValue(aeronave.maxDepartureWeight);
      this.maxLandingWeight.setValue(aeronave.maxLandingWeight);
      this.active.setValue(aeronave.active);
    })
    .catch(err => {
      console.error(err);

      this._snackBar.open('The aircraft could not be loaded.', '', { duration: 3000 });
    });
  }

  save() {
    if (this.registerAircraftFormGroup.valid) {

      let aircraft = new Aircraft();
      aircraft.prefix = this.prefix.value;
      aircraft.maxDepartureWeight = this.maxDepartureWeight.value;
      aircraft.maxLandingWeight = this.maxLandingWeight.value;
      aircraft.aircraftModel = this.aircraftModel.value;
      aircraft.active = this.active.value;

      ajax({
        url: `${environment.baseUrl}/Aeronave`,
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: aircraft
      })
        .toPromise()
        .then(() => this._router.navigateByUrl('/'))
        .catch(err => {
          console.error(err);
          
          this._snackBar.open('The aircraft could not be updated.', '', { duration: 3000 })
        })
    }
  }

  back() {
    window.history.back();
  }

  private _filter(value: string): AircraftModel[] {
    const filterValue = value.toLowerCase();

    return this.aircraftModels.filter(option => option.code.toLowerCase().indexOf(filterValue) === 0);
  }


}
