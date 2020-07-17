import { Component, OnInit } from '@angular/core';
import { SearchService } from 'src/app/components/search/services/search.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss'],
  providers: [SearchService]
})
export class SearchComponent implements OnInit {
  public returnedBooks: any[];
  public query: string;

  constructor(
    private searchService: SearchService
  ) { }

  ngOnInit() {
  }

  searchBook(query) {
    this.searchService.searchBook(query).subscribe(returnedBooks => {
      this.returnedBooks = returnedBooks;
    });
  }

  addFavorite(book) {
    this.searchService.addFavorites(book).subscribe();
  }

}
