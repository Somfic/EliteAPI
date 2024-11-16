import { writable } from "svelte/store";
import { type ErrorEvent } from "./bindings";

export interface State {
}

export class CatchingUpState implements State {
  constructor(percentage: number = 0) {
    this.percentage = percentage;
  }

  percentage: number;
}

export class ReadyState implements State {
}

export class ErrorState implements State {
  constructor(error: ErrorEvent) {
    this.error = error[0];
    this.isFatal = error[1];
  }

  error: string;
  isFatal: boolean;
}

export const state = writable<State>(new CatchingUpState());

export function setCatchingUp(percentage: number) {
  state.update((s) => {
    if (s instanceof CatchingUpState) {
      s.percentage = percentage;
      return s;
    } else {
      return new CatchingUpState(percentage);
    }
  });
}

export function setReady() {
  state.update((s) => {
    if (s instanceof ReadyState) {
      return s;
    } else {
      return new ReadyState();
    }
  });
}

export function setError(error: ErrorEvent) {
  state.update((s) => {
    if (s instanceof ErrorState) {
      s.error = error[0];
      s.isFatal = error[1];
      return s;
    } else {
      return new ErrorState(error);
    }
  });
}
