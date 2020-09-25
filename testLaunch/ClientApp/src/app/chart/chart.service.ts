import { Injectable, Inject } from '@angular/core';
import { GDPData } from './GDPData'
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class ChartService {
  public data: GDPData[];
  baseUrl: string;
  http: HttpClient;
  dataSub: Observable<GDPData[]>;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
   
  }

  GetData(): string{
    return "I am string";
  }

  GetGDPData(): any {
 //   if (this.data == null) {
 //     this.SetPresetData();
 //     console.log("couldn't get data from db");
  //  }
  //  return this.data;
    console.log("here");
    return this.http.get<GDPData[]>(this.baseUrl + 'gdpdata');
    //return this.http.get<GDPData[]>(this.baseUrl + 'gdpdata').map(result => {
    //  console.log("in get data");
    //  console.log(result);
    //  return result;
   // }, error => console.error(error));
   // console.log("after");
  }

  SetPresetData() {
    this.data = [{
      'country': 'USA',
      'subjectDescriptor': 'string',
      'units': 'string',
      'scale': 'string',
      'y2012': 1.2,
      'y2013': 1.2,
      'y2014': 1.2,
      'y2015': 1.2,
      'y2016': 1.2,
      'y2017': 1.2,
      'y2018': 1.2,
      'y2019': 1.2,
      'estimatesStartAfter': 2012
    },
    {
      'country': 'Japan',
      'subjectDescriptor': 'string',
      'units': 'string',
      'scale': 'string',
      'y2012': 10.2,
      'y2013': 10.2,
      'y2014': 10.2,
      'y2015': 10.2,
      'y2016': 10.2,
      'y2017': 10.2,
      'y2018': 10.2,
      'y2019': 10.2,
      'estimatesStartAfter': 2012
    }
    ];
  }

}
