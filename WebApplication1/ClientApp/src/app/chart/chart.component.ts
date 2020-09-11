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
    this._service.GetGDPData().subscribe(result => {
      console.log("in constructor");
      console.log(result);
      this.Forecasts = result;
      this.setupChart();
   }, error => console.error(error));
  }

  ngOnInit() {
    
  }

  setupChart() {
    var ctx = document.getElementById('myChart');
    console.log(this.Forecasts.length);
    var myChart = new Chart(ctx, {
      type: 'line',
      data: {
        labels: [2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019],
        datasets: []
      },
      options: {
        title: {
          display: true,
          text: 'World population per region (in millions)'
        }
      }
    });

    this.getLineData(myChart, this.Forecasts.pop(), "#3e95cd");
    this.getLineData(myChart, this.Forecasts.pop(), "#8e5ea2");
    this.getLineData(myChart, this.Forecasts.pop(), "#3cba9f");
    this.getLineData(myChart, this.Forecasts.pop(), "#e8c3b9");
    this.getLineData(myChart, this.Forecasts.pop(), "#c45850");
  }

  
  getLineData(chart,gdpdatavalue: GDPData, color:string) {
    var data = []
    data.push(gdpdatavalue.y2012)
    data.push(gdpdatavalue.y2013)
    data.push(gdpdatavalue.y2014)
    data.push(gdpdatavalue.y2015)
    data.push(gdpdatavalue.y2016)
    data.push(gdpdatavalue.y2017)
    data.push(gdpdatavalue.y2018)
    data.push(gdpdatavalue.y2019)
    console.log(gdpdatavalue.country);
    var label = gdpdatavalue.country;
    var borderColor =  color;
    var fill = false;
    var dataset = { data, label, borderColor, fill };
    chart.data.datasets.push(dataset);
    chart.update();
  }

}

