import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  //router - to redirect the user to an error page.
  //toastr - display a total notification
  constructor( private router: Router, private toastr: ToastrService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError(error => {
        if (error) {
          switch (error.status) {
            case 400:
              if(error.error.errors){
                //to flatten the array of errors that we get back from our validation responses and push them into an array.
                const modalStateErrors = [];
                for(const key in error.error.errors){
                  if (error.error.errors[key]){
                    modalStateErrors.push(error.error.errors[key])
                  }
                }
                //to return these errors back to the component
                throw modalStateErrors.flat();
              } else {
                this.toastr.error(error.statusText === "OK" ? "Bad Request" : error.statusText, error.status);
              }
              break;

          case 401:
            this.toastr.error(error.statusText === "OK" ? "Unauthorized" : error.statusText, error.status);
            break;

            case 404:                                
            this.router.navigateByUrl('/not-found'); //redirect to not found page
            break;


            case 500:   
            console.log(error);                        
              const navigationExtras: NavigationExtras = {state: {error: error.errors}}; //exception that we get back from our API
              this.router.navigateByUrl('/server-error', navigationExtras);

              break;

            default:
              this.toastr.error('something unexpected happened');
              break;
            }
          }
        
        return throwError(error);
      })
    );
  }
}
