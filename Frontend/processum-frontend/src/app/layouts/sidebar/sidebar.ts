import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { LucideAngularModule } from 'lucide-angular';
import { Scale, BadgeDollarSign, ChevronLeft, ChevronRight, BookUser, Menu } from 'lucide-angular/src/icons';
import { LayoutService } from '../services/layout-service';
import { RouterLink, RouterLinkActive } from '@angular/router';

const MODULES = [CommonModule, LucideAngularModule, RouterLink, RouterLinkActive];

@Component({
  selector: 'app-sidebar',
  imports: [...MODULES],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.css',
})
export class SidebarComponent {
  protected readonly Scale = Scale;
  protected readonly BadgeDollarSign = BadgeDollarSign;
  protected readonly ChevronLeft = ChevronLeft;
  protected readonly ChevronRight = ChevronRight;
  protected readonly BookUser = BookUser;
  protected readonly Menu = Menu;

  constructor(public layoutService : LayoutService) {}


}
