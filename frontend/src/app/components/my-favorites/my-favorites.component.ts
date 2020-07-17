import { Component, OnInit, Inject } from '@angular/core';
import { MyFavoritesService } from 'src/app/components/my-favorites/services/my-favorites.service';
import { ConfirmDialogModel, ConfirmDialogComponent } from 'src/app/components/confirm-dialog/confirm-dialog.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-my-favorites',
  templateUrl: './my-favorites.component.html',
  styleUrls: ['./my-favorites.component.scss'],
  providers: [MyFavoritesService]
})
export class MyFavoritesComponent implements OnInit {

  public favoriteBooks: any[];

  constructor(
    private myFavoritesService: MyFavoritesService,
    public dialog: MatDialog
  ) { }

  ngOnInit() {
    this.loadBooks();
  }

  loadBooks() {
    this.myFavoritesService.getFavorites().subscribe(books => this.favoriteBooks = books);
  }

  removeBook(bookId: string): void {
    const message = `Are you sure you want to remove the book from your favorites?`;

    const dialogData = new ConfirmDialogModel("Confirm book removal", message);

    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      maxWidth: "400px",
      data: dialogData
    });

    dialogRef.afterClosed().subscribe(dialogResult => {
      if (dialogResult) {
        this.myFavoritesService.removeFavorite(bookId).subscribe(() =>
          this.favoriteBooks = this.favoriteBooks.filter(book => book.id !== bookId)
        );
      }
    });
  }
}
