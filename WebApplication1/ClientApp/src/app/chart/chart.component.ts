import { Component } from '@angular/core';
import { Chart } from 'node_modules/chart.js'
import { ChartService } from './chart.service'
import {GDPData}  from './GDPData'

@Component({
  selector: 'app-chart-component',
  templateUrl: './chart.component.html',
  providers: [ChartService]
})
export class ChartComponent {
  Title: string = "";
  public Forecasts: GDPData[];

  constructor(private _service: ChartService) {
    this.Title = this._service.GetData();
    this.Forecasts = this._service.GetGDPData();
  }

  ngOnInit() {
    this.setupChart();
  }

  setupChart() {
    var ctx = document.getElementById('myChart');
    console.log(this.Forecasts.length);
    var myChart = new Chart(ctx, {
      type: 'line',
      data: {
        labels: [2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019],
        datasets: [{
          data: this.getLineData(this.Forecasts.pop()),
          label: "Africa",
          borderColor: "#3e95cd",
          fill: false
        }, {
          data: this.getLineData(this.Forecasts.pop()),
          label: "Asia",
          borderColor: "#8e5ea2",
          fill: false
        }, {
          data: [178, 190, 203, 276, 408, 547, 675, 734],
          label: "Europe",
          borderColor: "#3cba9f",
          fill: false
        }, {
          data: [10, 16, 24, 38, 74, 167, 508, 784],
          label: "Latin America",
          borderColor: "#e8c3b9",
          fill: false
        }, {
          data: [6, 3, 2, 2, 7, 26, 82, 172, 312, 433],
          label: "North America",
          borderColor: "#c45850",
          fill: false
        }
        ]
      },
      options: {
        title: {
          display: true,
          text: 'World population per region (in millions)'
        }
      }
    });
  }

  
  getLineData(gdpdatavalue: GDPData) {
    var data = []
    data.push(gdpdatavalue.y2012)
    data.push(gdpdatavalue.y2013)
    data.push(gdpdatavalue.y2014)
    data.push(gdpdatavalue.y2015)
    data.push(gdpdatavalue.y2016)
    data.push(gdpdatavalue.y2017)
    data.push(gdpdatavalue.y2018)
    data.push(gdpdatavalue.y2019)

  return data
}
}

