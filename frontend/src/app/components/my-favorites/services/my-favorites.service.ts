import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

const baseUrl = `${environment.API}/books`;

@Injectable()
export class MyFavoritesService {
    constructor(private httpClient: HttpClient) { }

    getFavorites() {
        return this.httpClient.get<any[]>(`${baseUrl}/GetFavorites`);
    }

    removeFavorite(id: string) {
        return this.httpClient.delete<any>(`${baseUrl}/RemoveFavorite/${id}`);
    }
}
