import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { VoyageService } from './services/voyages.service';
import { provideStore } from '@ngrx/store';
import { provideState } from '@ngrx/store';
import { provideEffects } from '@ngrx/effects';
import { ReportsEffects } from './state/reports.effects'
import { reportsFeatureKey, reportsReducer } from './state/reports.reducer';
import { VoyagesEffects } from './state/voyages.effects';
import { voyagesFeatureKey, voyagesReducer } from './state/voyages.reducer';
import { routes } from './app.routes';
import { provideCharts, withDefaultRegisterables } from 'ng2-charts';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient(),
    provideCharts(withDefaultRegisterables()),
    provideStore({}),
    provideState({ name: voyagesFeatureKey, reducer: voyagesReducer }),
    provideState({ name: reportsFeatureKey, reducer: reportsReducer }),
    provideEffects(VoyagesEffects, ReportsEffects),
    provideEffects(VoyagesEffects), VoyageService
  ]
};
