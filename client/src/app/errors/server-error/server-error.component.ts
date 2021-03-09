import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.component.html',
  styleUrls: ['./server-error.component.css']
})
export class ServerErrorComponent implements OnInit {
  error: any;

  //inject router, to get an access to the router state
  constructor(private router: Router) {
    //access the state 
    const navigation = this.router.getCurrentNavigation();
    this.error = navigation?.extras?.state?.error;
    
    
   }

  ngOnInit(): void {
  }

}
