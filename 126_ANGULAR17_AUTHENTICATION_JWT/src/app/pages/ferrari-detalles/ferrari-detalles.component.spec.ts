import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FerrariDetallesComponent } from './ferrari-detalles.component';

describe('FerrariDetallesComponent', () => {
  let component: FerrariDetallesComponent;
  let fixture: ComponentFixture<FerrariDetallesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FerrariDetallesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FerrariDetallesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
