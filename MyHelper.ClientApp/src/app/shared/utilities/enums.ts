export enum UserRole {
  Admin = 1,
  User = 2
}

export enum CardType {
  Task = 1,
  Note = 2,
  Friend = 3
}

export enum FilterType {
  TagsFilter = 1,
  DateTimeFilter = 2
}

export enum EditCardEventType {
  Save = 1,
  Cancel = 2
}

export enum RequestMethod {
  Get = 'GET',
  Post = 'POST',
  Put = 'PUT',
  Delete = 'DELETE',
  Options = 'OPTIONS',
  Head = 'HEAD',
  Patch = 'PATCH'
}

export enum Icons {
  Note = 'note',
  Schedule = 'schedule'
}

export enum MhTaskStatus {
  None = 0,
  Done = 1
}

export enum MhTaskVisibleType {
  Public = 1,
  Friend = 2,
  Private = 3
}

export enum ScheduleMhTaskType {
  None = 0,
  Daily = 1,
  Weekly = 7,
  Monthly = 30
}

export enum MhTaskState {
  Current = 1,
  Delete = 2,
  ReSchedule = 3
}
