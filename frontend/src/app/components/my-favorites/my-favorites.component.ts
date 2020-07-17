import { Component, OnInit } from '@angular/core';
import { MyFavoritesService } from 'src/app/components/my-favorites/services/my-favorites.service';

@Component({
  selector: 'app-my-favorites',
  templateUrl: './my-favorites.component.html',
  styleUrls: ['./my-favorites.component.scss'],
  providers: [MyFavoritesService]
})
export class MyFavoritesComponent implements OnInit {

  public favoriteBooks: any[];

  constructor(
    private myFavoritesService: MyFavoritesService
  ) { }

  ngOnInit() {
    this.myFavoritesService.getFavorites().subscribe(books => this.favoriteBooks = books);
  }

}
