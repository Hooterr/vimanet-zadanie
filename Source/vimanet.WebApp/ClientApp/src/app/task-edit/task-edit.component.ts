import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BackendService, TaskGroup } from '../backend.service';
import { Alert } from '../task-overview/task-overview.component';
import { HttpErrorResponse } from '@angular/common/http';


@Component({
  selector: 'app-task-edit',
  templateUrl: './task-edit.component.html'
})

export class TaskEditComponent implements OnInit{
  groupId: number;
  nameForm;
  taskForm;
  tasks: Task[];
  assignees: User[];
  creatingNewGroup: boolean;
  creatingNewTask: boolean;
  dataLoadError: boolean;
  alerts: Alert[] = [];
  displayNotif: boolean = true;

  constructor(private route: ActivatedRoute, private backend: BackendService, private formBuilder: FormBuilder, private router: Router) {
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.groupId = +params.get('id');
    });

    this.initializeFields();
  }

  initializeFields() {

    if (this.groupId === 0) {
      this.creatingNewGroup = true;
    }
    else {
      this.creatingNewTask = true;
      this.creatingNewGroup = false;
      this.dataLoadError = false;

      this.loadDataFromBackend();
    }

    this.nameForm = this.formBuilder.group({
      id: 0,
      name: '',
    })

    this.taskForm = this.formBuilder.group({
      id: 0,
      name: '',
      deadline: null,
      assignedUserId: 0,
      status: 0,
    })
  }

  loadAssigneesFromBackend() {
    this.backend.getUsers().subscribe(
      (response: User[]) => {
        this.assignees = response;
      },
      (error: HttpErrorResponse) => {
        this.alerts.push({
          message: 'Couldn\'t load the list of available assignees',
          type: 'danger',
        })
        this.assignees = [];
      });
  }
  loadDataFromBackend() {

    this.loadAssigneesFromBackend();

    this.backend.getTaskGroup(this.groupId).subscribe(
      (group: TaskGroup) => {
        if (group == null) {
          this.alerts.push({
            message: 'Error while fetching data',
            type: 'danger',
          })
          this.dataLoadError = true;
        }
        else {
          this.tasks = group.userTasks;
          this.fillGroupForm(group);
        }
      },
      error => {
        this.alerts.push({
          message: 'Error while fetching data',
          type: 'danger',
        })
        this.dataLoadError = true;
      })

  }

  onNameSubmit(group: TaskGroup) {
    this.backend.updateTaskGroup(group.id, group).subscribe(
      response => {
        if (response != null) {
          // New group created
          const newId: number = +response;
          this.groupId = newId;
          this.router.navigate(['/edit/' + newId]);
          // Reload page
          this.initializeFields();
        }
        this.alerts.push({
          message: 'Task group updated',
          type: 'success',
        });
      },
      error => {
        this.alerts.push({
          message: "An error occurred while updating the group.",
          type: "danger",
        })
      });
  }

  close(alert: Alert) {
    this.alerts.splice(this.alerts.indexOf(alert), 1);
  }

  onTaskSubmit(taskData: Task) {
    taskData.taskGroupId = this.groupId;
    this.backend.updateTask(taskData.id, taskData).subscribe(
      (response) => {
        this.alerts.push({
          message: 'Task added successfully',
          type: 'success',
        })
        this.createNewTask();
        this.loadDataFromBackend();
      },
      (error: HttpErrorResponse) => {
        this.alerts.push({
          message: 'Couldn\'t the add task',
          type: 'danger',
        })
      }
    );
  }

  refreshAssignees() {
    this.loadAssigneesFromBackend();
    // Check if the currently selected user hasn't been meanwhile deleted
    if (this.assignees.map((item: User) => item.id).indexOf(this.taskForm.controls['assignedUserId']) > -1)
    {
      this.taskForm.controls['assignedUserId'].setValue(0);
    }
  }

  onTaskDelete(task: Task) {
    this.backend.deleteTask(task.id).subscribe(
      (response) => {
        this.alerts.push({
          message: 'Task deleted successfully',
          type: 'success',
        })
        this.loadDataFromBackend();
      },
      (error: HttpErrorResponse) => {
        this.alerts.push({
          message: 'Couldn\'t delete task',
          type: 'danger',
        })
      });
  }

  onTaskSelect(task: Task) {
    this.creatingNewTask = false;
    this.fillTaskForm(task);
  }

  fillGroupForm(group: TaskGroup) {
    this.nameForm.reset();
    this.nameForm.controls['name'].setValue(group.name)
    this.nameForm.controls['id'].setValue(group.id);
  }

  fillTaskForm(task: Task) {
    this.taskForm.reset();
    this.taskForm.controls['id'].setValue(task.id);
    this.taskForm.controls['name'].setValue(task.name);
    this.taskForm.controls['deadline'].setValue(new Date(task.deadline).toISOString().substring(0, 10));
    this.taskForm.controls['assignedUserId'].setValue(task.assignedUserId);
    this.taskForm.controls['status'].setValue(task.status);
  }

  createNewTask() {
    this.resetNewTaskForm();
    this.creatingNewTask = true;
  }

  resetNewTaskForm() {
    this.taskForm.reset();
    this.taskForm.controls['id'].setValue(0);
    this.taskForm.controls['assignedUserId'].setValue(0);
    this.taskForm.controls['status'].setValue(0);
  }
}

export interface Task {
  id: number,
  name: string,
  deadline: Date,
  assignedUserId: number,
  status: TaskStatus,
  taskGroupId: number;
}

export enum TaskStatus {
  New=0,
  InProgress=1,
  Completed=2,
}

export interface User {
  firstName: string,
  lastName: string,
  id: number,
}
