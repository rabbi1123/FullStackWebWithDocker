import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddResourceComponent } from './add-resource/add-resource.component';
import { ResourceListComponent } from './resource-list/resource-list.component';

const routes: Routes = [
  {
    path: '',
    component: ResourceListComponent
  },
  {
    path: 'resources',
    component: ResourceListComponent
  },
  {
    path: 'resource/add',
    component: AddResourceComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
