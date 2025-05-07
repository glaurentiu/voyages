import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, mergeMap } from 'rxjs/operators';
import { VoyageService } from '../services/voyages.service';
import { loadVoyages, loadVoyagesSuccess, loadVoyagesFailure } from './voyages.actions';

@Injectable()
export class VoyagesEffects {
  loadVoyages$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadVoyages),
      mergeMap(() =>
        this.voyageService.getVoyages().pipe(
          map((voyages) => loadVoyagesSuccess({ voyages })),
          catchError((error) => of(loadVoyagesFailure({ error: error.message })))
        )
      )
    )
  );

  constructor(private actions$: Actions, private voyageService: VoyageService) { }
}