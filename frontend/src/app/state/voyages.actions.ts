import { createAction, props } from '@ngrx/store';
import { Voyage } from './voyages.reducer';

export const loadVoyages = createAction('[Voyages] Load Voyages');

export const loadVoyagesSuccess = createAction(
  '[Voyages] Load Voyages Success',
  props<{ voyages: Voyage[] }>()
);

export const loadVoyagesFailure = createAction(
  '[Voyages] Load Voyages Failure',
  props<{ error: string }>()
);