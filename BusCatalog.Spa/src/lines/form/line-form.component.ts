import { Component, OnInit } from '@angular/core';
import { BaseModule } from '../../base/base.module';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { BackEndValidationService } from 'base/back-end-validation/back-end-validation.service';
import { LineFormValidation } from './line-form.validation';
import { filter, switchMap, take } from 'rxjs';
import { LinesService } from 'lines/services/lines.service';
import { LineForm } from './line-form.interface';
import { Line } from 'lines/line';
import { VehiclesService } from 'vehicles/services/vehicles.service';
import { Vehicle } from 'vehicles/vehicle';

@Component({
  selector: 'app-line-form',
  standalone: true,
  imports: [BaseModule, ReactiveFormsModule, CommonModule],
  templateUrl: './line-form.component.html'
})
export class LineFormComponent implements OnInit {
  id?: number;
  form: FormGroup<LineForm>;
  messages = LineFormValidation.MESSAGES;
  vehicles: Vehicle[] = [];

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private service: LinesService,
    private vehiclesService: VehiclesService,
    public validator: BackEndValidationService) {
      this.form = LineFormValidation.generate();
    }

  ngOnInit() {
    this.validator.reset();

    this.vehiclesService.getAll()
      .pipe(take(1))
      .subscribe(vehicles => this.vehicles = vehicles);

    this.fillFormOnPut();
  }

  onListChanges(items: string[], field: string) {
    this.form.get(field)!.setValue(items);
  }

  onSubmit() {
    console.log(this.form.value);
    const line = Line.fromForm(this.form);

    this.service.save(line, this.id)
      .subscribe({
        next: _ => this.router.navigate(['']),
        error: error => this.validator.handleError(error)
      });
  }

  onDelete($event: MouseEvent) {
    $event.preventDefault();
    
    this.service.delete(this.id!)
      .subscribe({
        next: _ => this.router.navigate(['']),
        error: error => this.validator.handleError(error)
      })
  }

  private fillFormOnPut() {
    this.activatedRoute.params
      .pipe(
        take(1),
        filter(params => params['identification']),
        switchMap(params => this.service.getById(params['identification'])))
        .subscribe(({ id, identification, fromwards, towards, departuresPerDay, vehicles }) => {
        this.id = id;
        
        this.form.setValue({
          identification,
          fromwards,
          towards,
          departuresPerDay,
          vehicles
        });

        console.log(this.form.value);
      });
  }
}
