export class StatData {
    constructor(
      public statDataId: number,
      public year: number,
      public month: number,
      public day: number,
      public fromTime: string,
      public toTime: string,
      public hibaSum: number,
      public joSum: number,
      public repedtSum: number,
      public olajosSum: number,
      public torottszelSum: number
    ) {}
  }