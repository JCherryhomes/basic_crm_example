import { Component, OnInit, ChangeDetectionStrategy, Inject, ViewChild, ElementRef, OnDestroy, ChangeDetectorRef, TemplateRef } from '@angular/core';
import { AuthorizeService, IUser } from 'src/api-authorization/authorize.service';
import { Observable, BehaviorSubject, Subscription, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, FormControl, Validators, Form } from '@angular/forms';
import { debounceTime, distinctUntilChanged, tap, catchError } from 'rxjs/operators';
import { faArrowAltCircleDown } from '@fortawesome/free-regular-svg-icons';
import { NgbToastOptions } from '@ng-bootstrap/ng-bootstrap/toast/toast-config';
import { ToastService, IToast } from './toast-service.service';

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
  customerApiUrl = 'api/admin/customers';
  filterForm: FormGroup;
  customerForm: FormGroup;
  filterSubscription: Subscription;
  loading = false;
  toast: any = null;

  downArrow = faArrowAltCircleDown;

  filter = new BehaviorSubject<string>(null);
  selectedCustomer$ = new BehaviorSubject<ICustomer>(null);
  user$: Observable<IUser>;
  token$: Observable<string>;
  customers$: Observable<Object>;

  public get customerQuery(): string {
    return `?filter=${this.filter.value}&page=${this.page}&pageCount=${this.pageSize}&column=${this.column}`;
  }

  @ViewChild('toastDisplay', { static: true }) toastDisplay: any;

  public get filterControl(): FormControl {
    return this.filterForm.controls['filter'] as FormControl;
  }

  public get idControl(): FormControl {
    return this.customerForm.controls['id'] as FormControl;
  }

  public get firstNameControl(): FormControl {
    return this.customerForm.controls['firstName'] as FormControl;
  }

  public get lastNameControl(): FormControl {
    return this.customerForm.controls['lastName'] as FormControl;
  }

  constructor(
    private authorizeService: AuthorizeService,
    private http$: HttpClient,
    private formBuilder: FormBuilder,
    private changeRef: ChangeDetectorRef,
    public toastService: ToastService,
    @Inject('BASE_URL') private baseUrl: string) {
    this.user$ = authorizeService.getUser();
    this.token$ = authorizeService.getAccessToken();
    this.fetchCustomers(baseUrl);

    this.filterForm = formBuilder.group({
      filter: [null]
    });

    this.customerForm = formBuilder.group({
      id: [0],
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]]
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
    this.customerForm.patchValue({ firstName: customer.firstName });
    this.customerForm.patchValue({ lastName: customer.lastName });
    this.customerForm.patchValue({ id: customer.id });

    this.customerForm.markAsPristine();
  }

  create(): void {
    this.selectedCustomer$.next({ id: 0, firstName: '', lastName: '' });
    this.customerForm.patchValue({ firstName: '' });
    this.customerForm.patchValue({ lastName: '' });
    this.customerForm.patchValue({ id: 0 });

    this.customerForm.markAsPristine();
  }

  saveCustomer() {
    const successToast: IToast = {
      autohide: true,
      delay: 5000,
      header: 'SUCCESS',
      classname: 'customer-toast bg-success text-light'
    };

    const failToast:IToast = {
      autohide: true,
      delay: 5000,
      header: 'ERROR',
      classname: 'customer-toast bg-danger text-light'
    };

    if (this.customerForm.valid) {
      this.loading = true;
      const save$ = this.customerForm.controls['id'].value === 0 ?
        this.http$.post(`${this.baseUrl}${this.customerApiUrl}`, this.customerForm.value) :
        this.http$.put(`${this.baseUrl}${this.customerApiUrl}/${this.idControl.value}`, this.customerForm.value);

      save$.pipe(
        tap(() => this.fetchCustomers(this.baseUrl)),
        tap(() => this.loading = false),
        tap(() => this.selectedCustomer$.value.id === 0 ? this.create() : this.select(this.customerForm.value)),
        tap(() => this.toastService.show('Customer information was saved', successToast)),
        catchError(error => of(this.toastService.show('Customer information could not be saved', failToast)))
      ).subscribe();
    }
  }

  isTemplate(toast) {
    return toast.textOrTpl instanceof TemplateRef;
  }

  private fetchCustomers(baseUrl: string) {
    this.customers$ = this.http$.get<ICustomer[]>(`${baseUrl}${this.customerApiUrl}${this.customerQuery}`);
  }

  ngOnDestroy() {
    if (this.filterSubscription && !this.filterSubscription.closed) {
      this.filterSubscription.unsubscribe();
    }
  }
}
