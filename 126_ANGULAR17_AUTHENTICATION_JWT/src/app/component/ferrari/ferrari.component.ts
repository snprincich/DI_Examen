import { Component, Input } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Ferrari } from '../../interfaces/ferrari';

@Component({
  selector: 'app-ferrari',
  imports: [RouterModule],
  standalone: true,
  templateUrl: './ferrari.component.html',
  styleUrls: ['./ferrari.component.css']
})
export class FerrariComponent {
  @Input() ferrari!: Ferrari;
}
