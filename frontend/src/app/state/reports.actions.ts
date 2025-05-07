import { createAction, props } from '@ngrx/store';

export const loadVisitedCountries = createAction(
    '[Reports] Load Visited Countries'
);

export const loadVisitedCountriesSuccess = createAction(
    '[Reports] Load Visited Countries Success',
    props<{ countryCounts: Record<string, number> }>()
);

export const loadVisitedCountriesFailure = createAction(
    '[Reports] Load Visited Countries Failure',
    props<{ error: string }>()
);