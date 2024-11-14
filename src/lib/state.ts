import { writable } from "svelte/store";

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
  constructor(error: string) {
    this.error = error;
  }

  error: string;
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

export function setError(error: string) {
  state.update((s) => {
    if (s instanceof ErrorState) {
      s.error = error;
      return s;
    } else {
      return new ErrorState(error);
    }
  });
}
