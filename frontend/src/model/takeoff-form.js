import {Flight} from "./flight";

export class TakeoffForm {

  constructor() {
    this.takeoffTime = null;
    this.task = null;
    this.towplane = new Flight();
    this.gliders = new Array();
    this.withoutGlider = false;
  }

}
