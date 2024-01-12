import { sessionNavigationActions } from './game-navigation-actions';
import { SessionNavigationEffects } from './game-navigation-effects';

export const featureKey = 'game-session-navigation';
export const actions = sessionNavigationActions;
export const effects = SessionNavigationEffects;
