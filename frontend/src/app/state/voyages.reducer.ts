import { createReducer, on, Action } from '@ngrx/store';
import { isDevMode } from '@angular/core';
import { loadVoyages, loadVoyagesSuccess, loadVoyagesFailure } from './voyages.actions';

export const voyagesFeatureKey = 'voyages';

export interface Voyage {
  id: number;
  shipId: number;
  shipName: string;
  shipMaxSpeed: number;
  departurePortId: number;
  departurePortName: string;
  departureCountryName: string;
  arrivalPortId: number;
  arrivalPortName: string;
  arrivalCountryName: string;
  startTimestamp: string;
  endTimestamp: string;
}

export interface VoyagesState {
  voyages: Voyage[];
  loading: boolean;
  error: string | null;
}

export const initialState: VoyagesState = {
  voyages: [],
  loading: false,
  error: null,
};

export const voyagesReducer = createReducer(
  initialState,
  on(loadVoyages, (state) => ({ ...state, loading: true, error: null })),
  on(loadVoyagesSuccess, (state, { voyages }) => ({
    ...state,
    voyages,
    loading: false,
    error: null,
  })),
  on(loadVoyagesFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error,
  }))
);

export const metaReducers = isDevMode() ? [] : [];