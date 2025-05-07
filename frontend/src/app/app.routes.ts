import { Routes } from '@angular/router';
import { VoyagesComponent } from './components/voyages/voyages.component';
import { ReportsComponent } from './components/reports/reports.component';
export const routes: Routes = [
    {
        path: 'voyages',
        component: VoyagesComponent,
    },

    {
        path: 'reports',
        component: ReportsComponent,
    },

    { path: '', redirectTo: '/reports', pathMatch: 'full' },

    { path: '**', redirectTo: '/reports' },

];
