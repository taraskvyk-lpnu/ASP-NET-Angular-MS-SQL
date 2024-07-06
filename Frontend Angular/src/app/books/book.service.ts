import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import {Book} from "../models/book";

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor() { }

  addBook(book: Book) : Observable<Book> {
    return of(book);
  }

  removeBook(bookId : string) : Observable<string> {
    //return throwError(() => new Error(`Book with id ${bookId}`));
    return of(bookId);
  }
}
