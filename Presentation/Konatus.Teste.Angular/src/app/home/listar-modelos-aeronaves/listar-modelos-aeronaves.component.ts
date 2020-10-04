import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { AircraftModelService } from 'src/app/services/aircraft-model.service';
import { AircraftService } from 'src/app/services/aircraft.service';
import { AircraftModel } from 'src/entities/aircraft-model';

@Component({
  selector: 'app-listar-modelos-aeronaves',
  templateUrl: './listar-modelos-aeronaves.component.html',
  styleUrls: ['./listar-modelos-aeronaves.component.scss']
})
export class ListarModelosAeronavesComponent implements OnInit {

  prefix: string = '';
  displayedColumns = ['code', 'alternativeCode', 'maxDepartureWeight', 'maxLandingWeight'];
  dataSource = new MatTableDataSource<AircraftModel>([]);  

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private _aircraftModelService: AircraftModelService, private _snackBar: MatSnackBar, private _router: Router) { }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  ngOnInit(): void {

    this._aircraftModelService.getAll()
      .then(response => this.dataSource.data = response)
      .catch(this.catch);
  }

  edit(aircraftModel: AircraftModel) {
    
    this._router.navigateByUrl(`/aircraft-model/update/${aircraftModel.code}`);
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  catch = (err) => {
    console.error(err);

    this._snackBar.open('The aircraft could not be loaded.');
  }

}
