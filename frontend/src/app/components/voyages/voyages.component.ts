import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { CommonModule } from '@angular/common';
import { Store } from '@ngrx/store';
import { Voyage, VoyageService } from '../../services/voyages.service';
import { loadVoyages } from '../../state/voyages.actions';
import { selectVoyages, selectLoading, selectError } from '../../state/voyages.selectors';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-voyages',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatSortModule,
    MatInputModule,
    MatFormFieldModule,
    MatProgressSpinnerModule,
  ],
  templateUrl: './voyages.component.html',
  styleUrls: ['./voyages.component.scss'],
  providers: [VoyageService]
})
export class VoyagesComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = [
    'id',
    'shipName',
    'shipMaxSpeed',
    'departurePortName',
    'departureCountryName',
    'arrivalPortName',
    'arrivalCountryName',
    'startTimestamp',
    'endTimestamp',
  ];
  dataSource = new MatTableDataSource<Voyage>();
  voyages$: Observable<Voyage[]>;
  isLoading$: Observable<boolean>;
  error$: Observable<string | null>;

  @ViewChild(MatSort) sort!: MatSort;

  constructor(private store: Store) {
    this.voyages$ = this.store.select(selectVoyages);
    this.isLoading$ = this.store.select(selectLoading);
    this.error$ = this.store.select(selectError);
  }

  ngOnInit(): void {
    this.store.dispatch(loadVoyages());
    this.voyages$.subscribe((voyages) => {
      this.dataSource.data = voyages;
    });
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}