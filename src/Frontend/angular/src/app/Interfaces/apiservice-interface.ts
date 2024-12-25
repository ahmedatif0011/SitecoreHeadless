export type APIServiceInterface = {
  URLBase: string | null;
  url: string;
  headersObj: { [key: string]: string } | null;
  paramsObj: { [key: string]: string } | null;
  body: any | null;
  isFormData: boolean | null;
}
