import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ajax } from 'rxjs/ajax';
import { map, startWith } from "rxjs/operators";
import { Aircraft } from 'src/entities/aircraft';
import { AircraftModel } from 'src/entities/aircraft-model';
import { environment } from 'src/environments/environment';


@Component({
  selector: 'app-cadastro-aeronave',
  templateUrl: './cadastro-aeronave.component.html',
  styleUrls: ['./cadastro-aeronave.component.scss']
})
export class CadastroAeronaveComponent implements OnInit {

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

  registerAircraftFormGroup = new FormGroup({
    prefix: this.prefix,
    aircraftModel: this.aircraftModel,
    maxDepartureWeight: this.maxDepartureWeight,
    maxLandingWeight: this.maxLandingWeight
  });

  constructor(private _router: Router, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
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
    })
    .catch(err => {
      console.error(err);

      this._snackBar.open('The aircraft models could not be loaded.', '', { duration: 3000 });
    });
  }

  save() {
    if (this.registerAircraftFormGroup.valid) {

      let aircraft = new Aircraft();
      aircraft.prefix = this.prefix.value;
      aircraft.maxDepartureWeight = this.maxDepartureWeight.value;
      aircraft.maxLandingWeight = this.maxLandingWeight.value;
      aircraft.aircraftModel = this.aircraftModel.value;

      ajax({
        url: `${environment.baseUrl}/Aeronave`,
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: aircraft
      })
        .toPromise()
        .then(() => this._router.navigateByUrl('/'))
        .catch(err => {
          console.error(err);
          
          this._snackBar.open('The aircraft could not be saved.', '', { duration: 3000 })
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
