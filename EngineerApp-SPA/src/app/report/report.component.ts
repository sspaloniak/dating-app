import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {

  public barChartOptions = {
    scaleShowVerticalLines: false,
    responsive: true,
  };

  public barChartLabels = ['Programiści', 'Zarząd', 'Handlowcy', 'Wdrożeniowcy'];
  public barChartType = 'bar';
  public barChartLegend = true;

  public barChartData = [
    {data: [21500, 5600, 14800, 6500], label: 'Przychody'},
    {data: [16000, 10000, 9000, 9000], label: 'Koszty'}
  ];

  public barChartLabels2 = ['Davidson', 'Carry', 'Kowalski', 'Nowak', 'Naparstek', 'Pastuch'];
  public barChartData2 = [
    {data: [100, 95, 78, 85, 65, 73], label: 'Przychody'}
  ];

  public pieChartLabels = ['Poznań', 'Warszawa', 'Kraków'];
  public pieChartData = [2, 1, 1];
  public pieChartType = 'pie';
  public pieChartLegend = true;

  public doughnutChartLabels = ['Programiści', 'Zarząd', 'Handlowcy', 'Wdrożeniowcy'];
  public doughnutChartData = [2, 1, 2, 1];
  public doughnutChartType = 'doughnut';
  public doughnutChartLegend = true;

  constructor() { }

  ngOnInit() {
  }

}
