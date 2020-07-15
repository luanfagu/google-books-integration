import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SearchComponent } from 'src/app/components/search/search.component';
import { MyFavoritesComponent } from 'src/app/components/my-favorites/my-favorites.component';


const routes: Routes = [
  { path: 'search', component: SearchComponent },
  { path: 'my-favorites', component: MyFavoritesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
