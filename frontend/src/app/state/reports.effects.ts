import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, mergeMap, of } from 'rxjs';
import { ReportsService } from '../services/reports.service';
import { loadVisitedCountries, loadVisitedCountriesSuccess, loadVisitedCountriesFailure } from './reports.actions';

@Injectable()
export class ReportsEffects {
    loadVisitedCountries$ = createEffect(() =>
        this.actions$.pipe(
            ofType(loadVisitedCountries),
            mergeMap(() =>
                this.reportsService.getVisitedCountriesLastYear().pipe(
                    map(countryCounts => loadVisitedCountriesSuccess({ countryCounts })),
                    catchError(error => of(loadVisitedCountriesFailure({ error: error.message })))
                )
            )
        )
    );

    constructor(private actions$: Actions, private reportsService: ReportsService) { }
}