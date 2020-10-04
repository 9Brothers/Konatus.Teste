import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { environment } from 'src/environments/environment';
import { AircraftService } from '../services/aircraft.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  uploadForm: FormGroup;
  buttonFormControl = new FormControl();
  inputFormControl = new FormControl();

  constructor(private _aircraftService: AircraftService, private _snackBar: MatSnackBar, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.uploadForm = this.formBuilder.group({
      file: ['']
    });

  }

  onFileSelected() {
    const inputNode: any = document.querySelector('#file');

    if (typeof (FileReader) !== 'undefined') {
      // const reader = new FileReader();

      // reader.onload = (e: any) => {

      // };

      // reader.readAsArrayBuffer(inputNode.files[0]);

      const file = inputNode.files[0];
      this.uploadForm.get('file').setValue(file);

      let formData = new FormData();
      formData.append('file', this.uploadForm.get('file').value);      

      this._aircraftService.import(formData)
        .then(() => this._snackBar.open('File uploaded.', 'Ok', { duration: 3000 }))
        .catch(err => {
          console.error(err);

          this._snackBar.open('File cannot be uploaded.', '', { duration: 3000 });
        });
    }
  }

  export() {
    window.open(`${environment.baseUrl}/Aeronave/Actives/Excel`);
  }
}
