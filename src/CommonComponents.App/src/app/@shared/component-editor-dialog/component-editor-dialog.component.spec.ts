import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComponentEditorDialogComponent } from './component-editor-dialog.component';

describe('ComponentEditorDialogComponent', () => {
  let component: ComponentEditorDialogComponent;
  let fixture: ComponentFixture<ComponentEditorDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComponentEditorDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ComponentEditorDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
