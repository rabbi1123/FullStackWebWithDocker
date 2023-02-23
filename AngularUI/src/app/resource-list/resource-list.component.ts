import { Component, OnInit } from '@angular/core';
import { Resource } from '../Model/Resource.model';
import { ResourceService } from '../services/resource.service';

@Component({
  selector: 'app-resource-list',
  templateUrl: './resource-list.component.html',
  styleUrls: ['./resource-list.component.css']
})
export class ResourceListComponent implements OnInit {

  resources: Resource[] = [];

  constructor(private resourcesService: ResourceService) {}

  ngOnInit(): void {
    this.resourcesService.getAllResources().subscribe(res => {
      this.resources = res;
    });
  }
}
