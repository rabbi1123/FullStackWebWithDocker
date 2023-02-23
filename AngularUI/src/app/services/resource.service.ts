import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Resource } from '../Model/Resource.model';

@Injectable({
  providedIn: 'root'
})
export class ResourceService {

  baseUrl: string = 'http://localhost:8003';

  constructor(private http: HttpClient) { }

  getAllResources(): Observable<Resource[]> {
    return this.http.get<Resource[]>(this.baseUrl + '/api/Resource');
  }

  addResource(res: Resource): Observable<Resource> {
    return this.http.post<Resource>(this.baseUrl + '/api/Resource', res);
  }
}
