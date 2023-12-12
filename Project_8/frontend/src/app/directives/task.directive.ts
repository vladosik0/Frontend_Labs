import { AfterViewInit, Directive, ElementRef } from '@angular/core';

@Directive({
  selector: '[appTask]',
})
export class TaskDirective implements AfterViewInit {
  constructor(private el: ElementRef) {}

  public ngAfterViewInit(): void {
    const target: HTMLElement = this.el.nativeElement;
    const textContent = target.textContent?.trim().toLowerCase();

    const circle = document.createElement('span');
    circle.classList.add('status-circle');
    circle.style.width = '10px';
    circle.style.height = '10px';
    circle.style.borderRadius = '50%';
    circle.style.marginRight = '5px';
    circle.style.display = 'inline-block';

    switch (textContent) {
      case 'done':
        circle.style.backgroundColor = 'green';
        break;
      case 'to do':
        circle.style.backgroundColor = 'yellow';
        break;
      case 'in progress':
        circle.style.backgroundColor = 'blue';
        break;
      case 'canceled':
        circle.style.backgroundColor = 'red';
        break;
      default:
        break;
    }

    target.insertBefore(circle, target.firstChild);
  }
}
