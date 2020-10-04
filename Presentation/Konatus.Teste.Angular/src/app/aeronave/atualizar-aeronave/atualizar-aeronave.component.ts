import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';
import { AircraftModelService } from 'src/app/services/aircraft-model.service';
import { AircraftService } from 'src/app/services/aircraft.service';
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
  prefixParam: string = '';

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

  constructor(private _aircraftService: AircraftService, private _aircraftModelService: AircraftModelService, private _router: Router, private _route: ActivatedRoute, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {

    this._route.params.subscribe(params => {
      this.prefixParam = params['prefix'];
    });

    this._aircraftModelService.getAll()
      .then(response => {
        this.aircraftModels = response;

        this.filteredOptions = this.aircraftModel.valueChanges.pipe(
          startWith(''),
          map(value => this._filter(value))
        );

        return this._aircraftService.get(this.prefixParam);
      })
      .then(response => {

        let aeronave = response[0] as Aircraft;

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

      this._aircraftService.update(aircraft)
        .then(() => this._router.navigateByUrl('/'))
        .catch(err => {
          
        })
    }
  }

  delete() {
    this._aircraftService.delete(this.prefixParam)
      .then(() => this._router.navigateByUrl('/'))
      .catch(this.catch);
  }

  back() {
    window.history.back();
  }

  private _filter(value: string): AircraftModel[] {
    const filterValue = value.toLowerCase();

    return this.aircraftModels.filter(option => option.code.toLowerCase().indexOf(filterValue) === 0);
  }

  catch = (err) => {
    console.error(err);

    this._snackBar.open('The aircraft could not be updated.', '', { duration: 3000 });
  }
}
