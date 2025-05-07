import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { ChartConfiguration, ChartData, ChartType } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';
import { loadVisitedCountries } from '../../state/reports.actions';
import { reportsFeatureKey, ReportsState } from '../../state/reports.reducer';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-reports',
  standalone: true,
  imports: [BaseChartDirective, CommonModule],
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.scss'],
})
export class ReportsComponent implements OnInit {
  public barChartOptions: ChartConfiguration['options'] = {
    responsive: true,
    scales: {
      x: {
        title: {
          display: true,
          text: 'Countries Visited Last Year',
        },
      },
      y: {
        title: {
          display: true,
          text: 'Number of Visits',
        },
        beginAtZero: true,
        ticks: {
          stepSize: 1,
        },
      },
    },
    plugins: {
      legend: {
        display: false,
      },
    },
  };

  public barChartType: ChartType = 'bar';
  public barChartData: ChartData<'bar'> = {
    labels: [],
    datasets: [
      {
        data: [],
        label: 'Visited Countries',
        backgroundColor: [],
        borderColor: [],
        borderWidth: 1,
      },
    ],
  };

  loading$ = this.store.select(state => state[reportsFeatureKey].loading);
  error$ = this.store.select(state => state[reportsFeatureKey].error);
  countryCounts$ = this.store.select(state => state[reportsFeatureKey].countryCounts);

  constructor(private store: Store<{ [reportsFeatureKey]: ReportsState }>) { }

  ngOnInit(): void {

    this.store.dispatch(loadVisitedCountries());

    this.countryCounts$.subscribe(countryCounts => {
      if (countryCounts) {
        const countries = Object.keys(countryCounts);
        const visitCounts = Object.values(countryCounts);
        this.barChartData.labels = countries;
        this.barChartData.datasets[0].data = visitCounts;
        this.barChartData.datasets[0].backgroundColor = countries.map((_, index) =>
          index % 3 === 0 ? 'rgba(75, 192, 192, 0.5)' :
            index % 3 === 1 ? 'rgba(255, 99, 132, 0.5)' :
              'rgba(54, 162, 235, 0.5)'
        );
        this.barChartData.datasets[0].borderColor = countries.map((_, index) =>
          index % 3 === 0 ? 'rgba(75, 192, 192, 1)' :
            index % 3 === 1 ? 'rgba(255, 99, 132, 1)' :
              'rgba(54, 162, 235, 1)'
        );
      }
    });
  }
}