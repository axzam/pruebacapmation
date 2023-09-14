import { Component } from '@angular/core';
import { ClientService } from 'src/app/core/services/client.service';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-client-grid',
  templateUrl: './client-grid.component.html',
  styleUrls: ['./client-grid.component.css']
})
export class ClientGridComponent {

  clients: any[] = [];
  displayedClients: any[] = [];
  currentPage = 1;
  pageSize = 10; // Number of cards to display per page
  totalPages = 0;
  constructor(
    private clientService: ClientService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.loadClients();
  }

  loadClients(): void {
    this.clientService.getClients(this.pageSize, this.currentPage).subscribe(data => {
      this.displayedClients = data;
      console.log(data);
    });
  }

  nextPage(): void {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
      this.loadClients();
    }
  }

  previousPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.loadClients();
    }
  }

}
