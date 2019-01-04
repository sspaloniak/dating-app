import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { EventListComponent } from './event-list/event-list.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { MemberCardComponent } from './members/member-card/member-card.component';
import { RegisterComponent } from './register/register.component';
import { CardReadersComponent } from './card-readers/card-readers.component';

export const appRoutes: Routes = [
    { path: 'login', component: LoginComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'home', component: HomeComponent },
            { path: 'members', component: MemberListComponent},
            { path: 'register', component: RegisterComponent},
            { path: 'members/:id', component: MemberCardComponent},
            { path: 'events', component: EventListComponent },
            { path: 'cardreaders', component: CardReadersComponent}
        ]
    },
    { path: '**', redirectTo: 'login', pathMatch: 'full'}
];
