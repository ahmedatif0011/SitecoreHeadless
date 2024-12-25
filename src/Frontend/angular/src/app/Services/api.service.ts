import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { APIServiceInterface } from '../Interfaces/apiservice-interface';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }
  
  Get(request:APIServiceInterface): Observable<any> {
    request.URLBase = request.URLBase == null ? environment.sitecoreApiHost : request.URLBase;
    const cleanedHeaders = request.headersObj
      ? this.removeEmptyProperties(request.headersObj)
      : undefined;
    const cleanedParams = request.paramsObj
      ? this.removeEmptyProperties(request.paramsObj)
      : undefined;

    const options = {
      headers: cleanedHeaders,
      params: cleanedParams,
    };
    return this.http.get(request.URLBase + request.url, options);
  }
  POST(request : APIServiceInterface): Observable<any> {
    let headers = new HttpHeaders();
    let params = new HttpParams();
    request.URLBase = request.URLBase== null ? environment.sitecoreApiHost : request.URLBase;
    // If headersObj is provided and not null, add each header to HttpHeaders
    if (request.headersObj) {
      for (let key in request.headersObj) {
        if (request.headersObj.hasOwnProperty(key)) {
          headers = headers.set(key, request.headersObj[key]);
        }
      }
    }

    // If paramsObj is provided and not null, add each param to HttpParams
    if (request.paramsObj) {
      for (let key in request.paramsObj) {
        if (request.paramsObj.hasOwnProperty(key)) {
          params = params.set(key, request.paramsObj[key]);
        }
      }
    }

    // Convert body to FormData if isFormData is true
    let payload = request.body;
    if (request.isFormData && request.body) {
      payload = new FormData();
      for (let key in request.body) {
        if (request.body.hasOwnProperty(key)) {
          payload.append(key, request.body[key]);
        }
      }
    }
    const cleanedHeaders = request.headersObj
      ? this.removeEmptyProperties(request.headersObj)
      : undefined;
    const cleanedParams = request.paramsObj
      ? this.removeEmptyProperties(request.paramsObj)
      : undefined;

    // Build options object conditionally
    const options = {
      headers: cleanedHeaders,
      params: cleanedParams,
    };
    return this.http.post(request.URLBase + request.url, payload, options);
  }
  PUT(request : APIServiceInterface): Observable<any> {
    let headers = new HttpHeaders();
    let params = new HttpParams();
    request.URLBase = request.URLBase== null ? environment.sitecoreApiHost : request.URLBase;
    // If headersObj is provided and not null, add each header to HttpHeaders
    if (request.headersObj) {
      for (let key in request.headersObj) {
        if (request.headersObj.hasOwnProperty(key)) {
          headers = headers.set(key, request.headersObj[key]);
        }
      }
    }

    // If paramsObj is provided and not null, add each param to HttpParams
    if (request.paramsObj) {
      for (let key in request.paramsObj) {
        if (request.paramsObj.hasOwnProperty(key)) {
          params = params.set(key, request.paramsObj[key]);
        }
      }
    }

    // Convert body to FormData if isFormData is true
    let payload = request.body;
    if (request.isFormData && request.body) {
      payload = new FormData();
      for (let key in request.body) {
        if (request.body.hasOwnProperty(key)) {
          payload.append(key, request.body[key]);
        }
      }
    }

    const cleanedHeaders = request.headersObj
      ? this.removeEmptyProperties(request.headersObj)
      : undefined;
    const cleanedParams = request.paramsObj
      ? this.removeEmptyProperties(request.paramsObj)
      : undefined;

    // Build options object conditionally
    const options = {
      headers: cleanedHeaders,
      params: cleanedParams,
    };
    // Make the PUT request and return an Observable of ApiResponse<T>
    return this.http.put(request.URLBase + request.url, payload, options);
  }
  DELETE(request : APIServiceInterface): Observable<any> {
    let headers = new HttpHeaders();
    let params = new HttpParams();
    request.URLBase = request.URLBase== null ? environment.sitecoreApiHost : request.URLBase;
    // If headersObj is provided and not null, add each header to HttpHeaders
    if (request.headersObj) {
      for (let key in request.headersObj) {
        if (request.headersObj.hasOwnProperty(key)) {
          headers = headers.set(key, request.headersObj[key]);
        }
      }
    }

    // If paramsObj is provided and not null, add each param to HttpParams
    if (request.paramsObj) {
      for (let key in request.paramsObj) {
        if (request.paramsObj.hasOwnProperty(key)) {
          params = params.set(key, request.paramsObj[key]);
        }
      }
    }

    const cleanedHeaders = request.headersObj
      ? this.removeEmptyProperties(request.headersObj)
      : undefined;
    const cleanedParams = request.paramsObj
      ? this.removeEmptyProperties(request.paramsObj)
      : undefined;

    // Build options object conditionally
    const options = {
      headers: cleanedHeaders,
      params: cleanedParams,
    };

    // Make the DELETE request and return an Observable of ApiResponse<T>
    return this.http.delete(request.URLBase + request.url, options);
  }
  removeEmptyProperties(obj: { [key: string]: string | undefined }): {
    [key: string]: string;
  } {
    const result: { [key: string]: string } = {};

    // Iterate over the keys of the object
    for (const key in obj) {
      if (
        obj.hasOwnProperty(key) &&
        obj[key] !== undefined &&
        obj[key] !== null &&
        obj[key] !== ''
      ) {
        // Type assertion to ensure we're only adding non-undefined values
        result[key] = obj[key] as string;
      }
    }

    return result;
  }
}
