import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { AircraftService } from 'src/app/services/aircraft.service';
import { Aircraft } from 'src/entities/aircraft';

@Component({
  selector: 'app-listar-aeronaves',
  templateUrl: './listar-aeronaves.component.html',
  styleUrls: ['./listar-aeronaves.component.scss']
})
export class ListarAeronavesComponent implements OnInit, AfterViewInit {

  prefix: string = '';
  displayedColumns = ['prefix', 'maxDepartureWeight', 'maxLandingWeight', 'aircraftModel', 'active'];
  dataSource = new MatTableDataSource<Aircraft>([]);
  page: number = 0

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private _aircraftService: AircraftService, private _snackBar: MatSnackBar, private _router: Router) { }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  ngOnInit(): void {

    this._aircraftService.get('', this.page)
      .then(response => this.dataSource.data = response as Aircraft[])
      .catch(this.catch);
  }

  edit(aircraft: Aircraft) {
    
    this._router.navigateByUrl(`/aircraft/update/${aircraft.prefix}`);
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }


  onPageFired(event) {
    console.log(event);

    if (this.page > -1 && event.pageSize * (event.pageIndex + 1) >= event.length) {
      this.page++;

      this._aircraftService.get('', this.page)
        .then(response => {
          
          if (response.length < 50) {
            this.page = -1;
          }
          
          this.dataSource.data = this.dataSource.data.concat(response as Aircraft[])
        })
        .catch(this.catch);
    }
  }

  catch = (err) => {
    console.error(err);

    this._snackBar.open('The aircraft could not be loaded.');
  }


}
