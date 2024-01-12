import { EntityAdapter, EntityState, createEntityAdapter } from '@ngrx/entity';
import { GameRound } from 'src/app/models/game-round';

export const featureId = 'game-session-rounds';

export interface SessionRound extends GameRound { 
    isCompleted: boolean;
}

export interface RoundState extends EntityState<SessionRound> {
    selectedRoundId: string | undefined;
}

export interface RoundStoreState {
    rounds: RoundState;
}

export const roundAdapter: EntityAdapter<SessionRound> = createEntityAdapter<SessionRound>({
    selectId: (e) => e.id
});

export const initialRoundState: RoundState = roundAdapter.getInitialState({
    selectedRoundId: undefined
});
