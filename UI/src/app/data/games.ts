import { Game } from "../models/game";

export const games: Array<Game> = [
    {
        id: 'd12adfa5-26b5-4a6b-bd65-2dd02768437f',
        name: 'Game One',
        valueSymbol: '$',
        rounds: [
            {
                id: '43955bc2-06ca-4402-b52a-2ca27bb3bebc',
                type: 'Single',
                categoryIds: [
                    'd6eea9cf-8970-4ad6-bc40-aa08c265656e',
                    '670bfd57-7440-46eb-8693-76b1b8481c0a',
                    '90e3ae37-0b55-42c7-8bda-585b10c9695f',
                    'c1164106-b693-4424-8ce9-6cc6cc35cdff',
                    '9b5bc7a7-b4b2-46b8-8ac1-f93e5cb89b09'
                ],
                categories: []
            },
            {
                id: 'ea1d0e97-88ed-4244-9eb3-ea6ee73577d1',
                type: 'Double',
                categoryIds: [
                    '537e2ef1-64cd-4d99-8e5b-0f54cdb3a5e7',
                    '181a6157-1c47-4e57-823f-d547ad7bd18c',
                    '52b12ccb-62dd-4463-98b3-e782e4c3f842',
                    '12606096-9cb4-4cae-ac6b-b58296e62152',
                    'e0989a35-a762-469d-a351-bcedb98a67f4',
                ],
                categories: []
            }
        ]
    }
];
