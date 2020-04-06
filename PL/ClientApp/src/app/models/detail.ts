export class Detail {
    constructor(
        public id?: number,
        public nomenclatureCode?: string,
        public name?: string,
        public quantity?: number,
        public created?: Date,
        public deleteDate?: Date,
        public storekeeperId?: number) { }
}