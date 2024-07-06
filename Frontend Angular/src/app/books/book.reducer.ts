import { createReducer, on } from "@ngrx/store";
import {
  AddBook,
  RemoveBook,
  AddBookSuccess,
  AddBookFailure,
  RemoveBookSuccess,
  RemoveBookFailure
} from "./book.actions";
import { Book } from "../models/book";

export const initialState: Book[] = [];

export const BookReducer = createReducer(
  initialState,
  on(AddBook, (state) => { return state }),
  on(AddBookSuccess, (state, {id, title, author }) =>
  {
    console.log('Reducer - Books Added:');
    return [...state, { id, title, author }]
  }),
  on(AddBookFailure, (state, {error}) => {
    console.log(error)
    return state;
  }),

  on(RemoveBook, (state, {bookId}) => {return state}),
  on(RemoveBookSuccess, (state, {bookId }) =>
  {
    console.log('Reducer - Books Removed:');
    return state.filter(book => book.id !== bookId)
  }),
  on(RemoveBookFailure, (state, {error}) => {
    console.log(error);
    return state;
  })
);
