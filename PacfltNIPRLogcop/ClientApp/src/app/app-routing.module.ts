import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CounterComponent } from './counter/counter.component';
import { MapComponent } from './map/map.component';
import { HomeComponent } from './home/home.component';
import { ChartComponent } from './chart/chart.component';


const routes: Routes = [{ path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'map', component: MapComponent },
  { path: 'chart', component: ChartComponent}
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
