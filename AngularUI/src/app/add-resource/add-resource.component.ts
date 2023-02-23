import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Resource } from '../Model/Resource.model';
import { ResourceService } from '../services/resource.service';

@Component({
  selector: 'app-add-resource',
  templateUrl: './add-resource.component.html',
  styleUrls: ['./add-resource.component.css']
})
export class AddResourceComponent implements OnInit {

  resource: Resource = {
    id: 0,
    resourceName: ''
  };

  constructor(private resourceService: ResourceService, private router: Router) {}

  ngOnInit():void {}

  addResource() {
    this.resourceService.addResource(this.resource).subscribe(n => {
      this.router.navigate(['resources']);
    });
  }
}
