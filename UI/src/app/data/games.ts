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
                ]
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
                ]
            }
        ]
    },
    {
        id: '71807a01-8dc2-40b9-ac9c-6977c3371357',
        name: 'Game Two',
        valueSymbol: '$',
        rounds: [
            {
                id: '0e50f6f6-b82c-4742-8c49-835fee00d65b',
                type: 'Single',
                categoryIds: [
                    '8ed12b92-a93d-4dba-bc31-822b3de90e88',
                    'f8d170ab-d06a-4b0b-bdb0-ea1760a62252',
                    'e27039c1-b06e-4e98-ae59-c859e1f1a1e6',
                    '418abaa2-3922-4d60-9f03-44f01f08a09d',
                    'de109484-dbd4-4c18-a5f7-e4185b678d03'
                ]
            },
            {
                id: '3207272f-aa1c-4e3c-b90b-502cad03db79',
                type: 'Double',
                categoryIds: [
                    'f7d76093-b499-42ec-8213-d4b4651c38d1',
                    '073b3bd9-fbf3-4e0a-b232-3ac061c01510',
                    'f0de5d11-7c85-461c-881a-fcd5c6e72634',
                    'e6b81ed5-d089-4793-93ac-a1df5b2cd881',
                    'eddc2c16-a422-4c93-ae31-7cd9fd605e9a'
                ]
            }
        ]
    }
];
