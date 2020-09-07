export interface IServiceResponse<T>{
    isSeccess:boolean;
    message:string;
    time:Date,
    data:T;
}