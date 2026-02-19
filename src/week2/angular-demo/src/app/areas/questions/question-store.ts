import { httpResource } from '@angular/common/http';
import { signalStore, withHooks, withProps } from '@ngrx/signals';

import { GetQuestionsResponse } from '../shared/api';
export const QuestionStore = signalStore(
  withProps(() => {
    return {
      questionResource: httpResource<GetQuestionsResponse>(() => '/api/questions'),
    };
  }),
  withHooks({
    onInit(store) {
      console.log('The QuestionStore has been initialized.');
      // set a timer, ever X minutes or so, do this:
      // setInterval(() => {
      //   store.questionResource.reload();
      // }, 5000);
    },
    onDestroy(store) {
      console.log('The QuestionStore is being destroyed.');
    },
  }),
);
