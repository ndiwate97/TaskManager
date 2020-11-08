import { Injectable } from '@angular/core';
//Performs HTTP requests. 
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class AppServiceService {

  //creating object of HttpClient.
  constructor(public http: HttpClient) { }

  login(data) {
    return this.http.post("https://localhost:44304/api/v1/login", data);
  }

  register(data) {
    return this.http.post("https://localhost:44304/api/v1/user/Register", data);
  }

  getAllTask(id) {
    return this.http.get("https://localhost:44304/api/v1/user/" + id + "/task");
  }

  getUserById(id) {
    return this.http.get("https://localhost:44304/api/v1/user/" + id);
  }

  deleteTask(userId, taskId) {
    return this.http.delete("https://localhost:44304/api/v1/user/" + userId + "/task/DeleteTask?taskId=" + taskId);
  }

  addTask(data, userId) {
    return this.http.post("https://localhost:44304/api/v1/user/" + userId + "/task/AddTask", data);
  }

  getTaskById(userId, taskId) {
    return this.http.get("https://localhost:44304/api/v1/user/" + userId + "/task/" + taskId);
  }

  updateTask(data, userId, taskId) {
    return this.http.put("https://localhost:44304/api/v1/user/" + userId + "/task/UpdateTask/" + taskId, data);
  }

  getAllSubTask(userId, taskId) {
    return this.http.get("https://localhost:44304/api/v1/user/" + userId + "/task/" + taskId + "/subTask");
  }

  addSubtask(data, userId, taskId) {
    return this.http.post("https://localhost:44304/api/v1/user/" + userId + "/task/" + taskId + "/subTask/AddSubTask", data);
  }

  getSubtaskById(userId, taskId, subtaskId) {
    return this.http.get("https://localhost:44304/api/v1/user/" + userId + "/task/" + taskId + "/subTask/"+subtaskId);
  }

  updateSubtask(data,userId, taskId, subtaskId) {
    return this.http.put("https://localhost:44304/api/v1/user/" + userId + "/task/" + taskId + "/subTask/UpdateSubTask/" + subtaskId, data);
  }

  
  deleteSubtask(userId, taskId, subtaskId) {
    return this.http.delete("https://localhost:44304/api/v1/user/"+userId+"/task/"+taskId+"/subTask/DeleteSubTask?subTaskId="+subtaskId)
  }
}
