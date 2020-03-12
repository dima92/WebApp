export class Detail {
  constructor(
    public id: number,
    public nomenclatureCode: string,
    public name: string,
    public quantity: number,
    public specAccount: boolean,
    public createDate: Date,
    public deleteDate: Date
  ) { }
}
