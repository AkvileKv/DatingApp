import { Component, Input, OnInit, Self } from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';

@Component({
  selector: 'app-text-input',
  templateUrl: './text-input.component.html',
  styleUrls: ['./text-input.component.css']
})
export class TextInputComponent implements ControlValueAccessor {
@Input() label: string;
@Input() type: 'text';

//inject the control into the constructor of ControlValueAccessor component
  constructor(@Self() public ngControl: NgControl) { 
    this.ngControl.valueAccessor = this;
    
  }

  writeValue(obj: any): void {

  }
  registerOnChange(fn: any): void {

  }
  registerOnTouched(fn: any): void {

  }
 
}
