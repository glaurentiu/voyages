import { createReducer, on } from '@ngrx/store';
import { loadVisitedCountries, loadVisitedCountriesSuccess, loadVisitedCountriesFailure } from './reports.actions';

export interface ReportsState {
    countryCounts: Record<string, number> | null;
    loading: boolean;
    error: string | null;
}

export const initialState: ReportsState = {
    countryCounts: null,
    loading: false,
    error: null,
};

export const reportsFeatureKey = 'reports';

export const reportsReducer = createReducer(
    initialState,
    on(loadVisitedCountries, (state) => ({
        ...state,
        loading: true,
        error: null,
    })),
    on(loadVisitedCountriesSuccess, (state, { countryCounts }) => ({
        ...state,
        countryCounts,
        loading: false,
        error: null,
    })),
    on(loadVisitedCountriesFailure, (state, { error }) => ({
        ...state,
        loading: false,
        error,
    }))
);