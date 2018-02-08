import { Component, OnInit } from '@angular/core';
import { NoteResponse } from '../../shared/models/notes/note-response.model';
import { NoteService } from '../../shared/services/note.service';
import { ICard } from '../../shared/models/base/i-card.model';
import { CardType, FilterType } from '../../shared/utilities/enums';
import { FilterItem } from '../../shared/models/base/filter-item.model';
import { NoteFilterRequest } from '../../shared/models/notes/note-filter-request';

@Component({
  selector: 'mh-notes-page',
  templateUrl: './notes-page.component.html',
  styleUrls: ['./notes-page.component.scss']
})
export class NotesPageComponent implements OnInit {

  notes: ICard<NoteResponse>[];
  filterItems: FilterItem[];
  noteFilterRequest: NoteFilterRequest;
  detailedNote: NoteResponse;
  isNoteListVisible = true;

  constructor(private noteService: NoteService) { }

  ngOnInit() {
    this.filterItems = [new FilterItem(FilterType.TagsFilter, 'Tags')];
    this.noteFilterRequest = new NoteFilterRequest();

    this._getNotes();
  }

  addNote() {
    this.detailedNote = new NoteResponse();
    this.isNoteListVisible = false;
  }

  updateNote(note: NoteResponse) {
    this.isNoteListVisible = false;
    this.detailedNote = note;
  }

  deleteNote(id: number) {
    this.noteService.deleteNote(id)
      .subscribe((result: boolean) => {
        if (result) {
          this._getNotes();
        }
      });
  }

  closeDetailedNoteView(value: boolean) {
    this._getNotes();
    this.isNoteListVisible = value;
  }

  triggerChangeWrapFilter(wrapFilter) {
    Object.keys(wrapFilter)
    .forEach(key => {
      this.noteFilterRequest[key] = wrapFilter[key];
    });
    this._getNotes();
  }

  triggerChangeSearch(search) {
    this.noteFilterRequest.search = search;
    this._getNotes();
  }

  private _getNotes() {
    this.noteService.getNotes(this.noteFilterRequest)
    .subscribe((noteResponseList: NoteResponse[]) => {
      this.notes = noteResponseList.map((x) => {
        return { data : x, cardType : CardType.Note } as ICard<NoteResponse>;
      });
    });
  }
}
