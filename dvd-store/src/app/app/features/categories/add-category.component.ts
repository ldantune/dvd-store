import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../core/services/category.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-category',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule ],
  templateUrl: './add-category.component.html',
  styleUrl: './add-category.component.css'
})
export class AddCategoryComponent implements OnInit {
  categoryForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private categoryService: CategoryService
  ) {}

  ngOnInit(): void {
    // Inicializa o formulário com campos e validação
    this.categoryForm = this.fb.group({
      name: ['', Validators.required],
      lastUpdate: [new Date().toISOString(), Validators.required]
    });
  }

  onSubmit(): void {
    if (this.categoryForm.valid) {
      const categoryData = this.categoryForm.value;
      this.categoryService.addCategory(categoryData).subscribe({
        next: (response) => {
          console.log('Category added successfully', response);
        },
        error: (error) => {
          console.error('Error adding category', error);
        }
      });
    }
  }
}
