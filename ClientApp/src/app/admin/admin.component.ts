import { Component, OnInit, ChangeDetectionStrategy, Inject, ViewChild, ElementRef, OnDestroy, ChangeDetectorRef } from '@angular/core';
import { AuthorizeService, IUser } from 'src/api-authorization/authorize.service';
import { Observable, BehaviorSubject, Subscription } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { debounceTime, distinctUntilChanged, tap } from 'rxjs/operators';
import { faArrowAltCircleDown } from '@fortawesome/free-regular-svg-icons';

export interface ICustomer {
  id: number;
  firstName: string;
  lastName: string;
}

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AdminComponent implements OnInit, OnDestroy {
  page = 1;
  pageSize = 10;
  column = 'FirstName';
  filter = new BehaviorSubject<string>(null);
  selectedCustomer$ = new BehaviorSubject<ICustomer>(null);
  filterForm: FormGroup;
  filterSubscription: Subscription;

  downArrow = faArrowAltCircleDown;

  user$: Observable<IUser>;
  token$: Observable<string>;
  customers$: Observable<Object>;

  public get customerQuery(): string {
    return `?filter=${this.filter.value}&page=${this.page}&pageCount=${this.pageSize}&column=${this.column}`;
  }

  public get filterControl(): FormControl {
    return this.filterForm.controls['filter'] as FormControl;
  }

  constructor(
    private authorizeService: AuthorizeService,
    private http$: HttpClient,
    private formBuilder: FormBuilder,
    private changeRef: ChangeDetectorRef,
    @Inject('BASE_URL') private baseUrl: string) {
    this.user$ = authorizeService.getUser();
    this.token$ = authorizeService.getAccessToken();
    this.fetchCustomers(baseUrl);
    this.filterForm = formBuilder.group({
      filter: [null]
    });
  }

  ngOnInit() {
    this.filterSubscription = this.filterControl.valueChanges.pipe(
      debounceTime(300),
      tap(value => this.filter.next(value)),
      tap(() => this.fetchCustomers(this.baseUrl)),
      tap(() => this.changeRef.detectChanges())
    ).subscribe();
  }

  changePage(page: number): void {
    this.page = page;
    this.fetchCustomers(this.baseUrl);
  }

  sort(column: string): void {
    this.column = column;
    this.fetchCustomers(this.baseUrl);
  }

  select(customer: ICustomer): void {
    this.selectedCustomer$.next(customer);
  }

  private fetchCustomers(baseUrl: string) {
    this.customers$ = this.http$.get<ICustomer[]>(`${baseUrl}api/admin/customers${this.customerQuery}`);
  }

  ngOnDestroy() {
    if (this.filterSubscription && !this.filterSubscription.closed) {
      this.filterSubscription.unsubscribe();
    }
  }
}
