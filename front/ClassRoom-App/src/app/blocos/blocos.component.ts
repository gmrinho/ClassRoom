import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-blocos',
  templateUrl: './blocos.component.html',
  styleUrls: ['./blocos.component.scss']
})
export class BlocosComponent implements OnInit {

  public blocos: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getBlocos();
  }

  public getBlocos(): void {
    this.http.get('https://localhost:5001/api/Blocos').subscribe(
      response => this.blocos = response,
      error => console.log(error)
    );
  }

}
