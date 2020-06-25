import { Component, Directive, EventEmitter, Input, OnInit, Output, QueryList, ViewChildren } from '@angular/core';
import { BackendService } from '../backend.service';

export type SortColumn = keyof TaskOverviewItem | '';
export type SortDirection = 'asc' | 'desc' | '';
const rotate: { [key: string]: SortDirection } = { 'asc': 'desc', 'desc': '', '': 'asc' };
const compare = (v1: string, v2: string) => v1 < v2 ? -1 : v1 > v2 ? 1 : 0;

export interface SortEvent {
  column: SortColumn;
  direction: SortDirection;
}

export interface Alert {
  type: string,
  message: string,
}

@Directive({
  selector: 'th[sortable]',
  host: {
    '[class.asc]': 'direction === "asc"',
    '[class.desc]': 'direction === "desc"',
    '(click)': 'rotate()'
  }
})
export class NgbdSortableHeader {

  @Input() sortable: SortColumn = '';
  @Input() direction: SortDirection = '';
  @Output() sort = new EventEmitter<SortEvent>();

  rotate() {
    this.direction = rotate[this.direction];
    this.sort.emit({ column: this.sortable, direction: this.direction });
  }
}

@Component({
  selector: 'app-task-overview',
  templateUrl: './task-overview.component.html'
})

export class TaskOverviewComponent implements OnInit {
  public tasks: TaskOverviewItem[];
  public alerts: Alert[] = []
  constructor(private backend: BackendService ) {
  }

  ngOnInit() {
    this.loadData();
  }

  @ViewChildren(NgbdSortableHeader) headers: QueryList<NgbdSortableHeader>;

  loadData() {
    this.backend.getTaskOverview().subscribe((tasks: TaskOverviewItem[]) => {
      this.tasks = tasks;
    });
  }

  onSort({ column, direction }: SortEvent) {

    // resetting other headers
    this.headers.forEach(header => {
      if (header.sortable !== column) {
        header.direction = '';
      }
    });
    
    if (direction === '' || column === '') {
      column = 'id';
      direction = 'asc';
    }
    this.tasks = this.tasks.sort((a, b) => {
      const res = compare(`${a[column]}`, `${b[column]}`);
      return direction === 'asc' ? res : -res;
    });
  }

  close(alert: Alert) {
    this.alerts.splice(this.alerts.indexOf(alert), 1);
  }

  onDeleteGroup(task: TaskOverviewItem) {
    console.log('Deleting task: ')
    console.log(task)
    task.busy = true;
    this.backend.deleteTaskGroup(task.id).subscribe(
      (response) => {
          this.alerts.push({
            message: "Group deleted successfully",
            type: "success",
          })
        this.loadData()
      },
      (error) => {
        this.alerts.push({
          message: "An error occurred while deleting the group.",
          type: "danger",
        })
        task.busy = false;
      });
  }
}

export interface TaskOverviewItem {
  id: number;
  name: string;
  totalNumberOfTasks: number;
  busy: boolean;
}
