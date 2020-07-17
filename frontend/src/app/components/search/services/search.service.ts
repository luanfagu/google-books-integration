import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

const baseUrl = `${environment.API}/books`;

@Injectable()
export class SearchService {
    constructor(private httpClient: HttpClient) { }

    addFavorites(book) {
        return this.httpClient.post<any>(`${baseUrl}`, book);
    }

    searchBook(query: string) {
        return this.httpClient.get<any[]>(`${baseUrl}/SearchBook/${query}`);
    }
}
