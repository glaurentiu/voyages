import { createFeatureSelector, createSelector } from '@ngrx/store';
import { VoyagesState, voyagesFeatureKey } from './voyages.reducer';

export const selectVoyagesState = createFeatureSelector<VoyagesState>(voyagesFeatureKey);

export const selectVoyages = createSelector(
  selectVoyagesState,
  (state) => state.voyages
);

export const selectLoading = createSelector(
  selectVoyagesState,
  (state) => state.loading
);

export const selectError = createSelector(
  selectVoyagesState,
  (state) => state.error
);