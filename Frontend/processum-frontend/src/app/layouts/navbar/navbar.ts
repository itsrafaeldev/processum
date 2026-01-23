import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { LucideAngularModule } from 'lucide-angular';
import { Menu } from 'lucide-angular/src/icons';
import { LayoutService } from '../services/layout-service';
const MODULES = [CommonModule, LucideAngularModule];


@Component({
  selector: 'app-navbar',
  imports: [...MODULES],
  templateUrl: './navbar.html',
  styleUrl: './navbar.css',
})
export class NavbarComponent {
  protected readonly Menu = Menu;
  constructor(public layoutService : LayoutService) {}


}
