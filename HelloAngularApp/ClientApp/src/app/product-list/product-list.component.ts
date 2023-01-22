import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { Product } from '../product';

@Component({
    templateUrl: './product-list.component.html',
    providers: [DataService]
})
export class ProductListComponent implements OnInit {

    products: Product[];
    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.dataService.getProducts().subscribe((data: Product[]) => this.products = data);
    }
}