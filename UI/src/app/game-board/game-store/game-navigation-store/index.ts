import * as navigationActions from './game-navigation-actions';
import * as navigationEffects from './game-navigation-effects';

export const featureKey = 'game-session-navigation';
export const actions = navigationActions.sessionNavigationActions;
export const effects = navigationEffects.SessionNavigationEffects;
