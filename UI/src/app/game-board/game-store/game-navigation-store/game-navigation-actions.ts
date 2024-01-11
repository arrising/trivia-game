import { createActionGroup, emptyProps, props } from "@ngrx/store";

export const sessionNavigationActions = createActionGroup({
    source: 'Session Navigation',
    events: {
        'Exit Games': emptyProps(),
        'View Game Selector': emptyProps(),
        'View Round Selector': emptyProps(),
        'View Round': props<{ roundId: string }>(),
        'View Question': props<{ id: string }>(),
        'View Answer': props<{ id: string }>(),
    }
});
