import { Game } from "../models/game";
import { GameRound } from "../models/game-round";

export const games: Array<Game> = [
    {
        id: 'd12adfa5-26b5-4a6b-bd65-2dd02768437f',
        name: 'Game One',
        valueSymbol: '$',
        rounds: [
            {
                id: '43955bc2-06ca-4402-b52a-2ca27bb3bebc',
                type: 'Single',
                categories: [
                    {
                        id: 'd6eea9cf-8970-4ad6-bc40-aa08c265656e',
                        name: 'Sabbats',
                        questions: [
                            {
                                questionId: '58484667-2208-46f4-ba96-0cd2b166a39d',
                                value: 100
                            },
                            {
                                questionId: '20c9cc0d-317f-4658-811d-986c9dc9c4c0',
                                value: 200
                            },
                            {
                                questionId: '3171a860-b594-4f75-8ccb-153b8b653650',
                                value: 300
                            },
                            {
                                questionId: 'f17cd298-c728-4540-8b5f-7b383e243dad',
                                value: 400
                            },
                            {
                                questionId: 'b24f3d67-9126-4639-b9fa-e6eb0412734d',
                                value: 500
                            }
                        ]
                    },
                    {
                        id: '670bfd57-7440-46eb-8693-76b1b8481c0a',
                        name: 'Mythological Monsters',
                        questions: [
                            {
                                questionId: 'bc05d953-1f39-4056-875b-a0d5d5733cc4',
                                value: 100
                            },
                            {
                                questionId: '689fbc5f-88fd-471f-b37a-61bcc17dc9a0',
                                value: 200
                            },
                            {
                                questionId: '37ad49ed-bf4e-4c11-8ee5-14685acbd3d2',
                                value: 300
                            },
                            {
                                questionId: 'e4f87f91-c33e-4986-be38-c58312ace22f',
                                value: 400
                            },
                            {
                                questionId: 'f7cc9963-f60c-4a66-8f1d-0238b4443383',
                                value: 500
                            }
                        ]
                    },
                    {
                        id: '90e3ae37-0b55-42c7-8bda-585b10c9695f',
                        name: '“A” Rolling Stone',
                        questions: [
                            {
                                questionId: '8c57c6e9-8c1f-4911-872c-6739d1f36c09',
                                value: 100
                            },
                            {
                                questionId: '18609b15-bf2b-4042-b43d-602733620aae',
                                value: 200
                            },
                            {
                                questionId: 'bb71a25a-3f99-4bcc-b954-b0660a4a3565',
                                value: 300
                            },
                            {
                                questionId: '4f26c3aa-ad75-4fe2-8170-45bb90873dc4',
                                value: 400
                            },
                            {
                                questionId: '123db793-3bd4-4fd6-9508-67f093609277',
                                value: 500
                            }
                        ]
                    },
                    {
                        id: 'c1164106-b693-4424-8ce9-6cc6cc35cdff',
                        name: 'The Fae',
                        questions: [
                            {
                                questionId: '9a487faa-6dd5-4ce0-879f-9a81826fb7c3',
                                value: 100
                            },
                            {
                                questionId: 'e09d82e3-156c-45df-b243-79dcd71248ec',
                                value: 200
                            },
                            {
                                questionId: '3effe6d8-14dd-4492-8728-4626d088cbc3',
                                value: 300
                            },
                            {
                                questionId: '8ea3b32b-3eda-410c-9e1d-3571f6e01207',
                                value: 400
                            },
                            {
                                questionId: '669517b1-1ab4-4e56-9706-eee94c381627',
                                value: 500
                            }
                        ]
                    },
                    {
                        id: '9b5bc7a7-b4b2-46b8-8ac1-f93e5cb89b09',
                        name: 'Ancient Architecture',
                        questions: [
                            {
                                questionId: 'dcb2b008-38be-49c6-987d-1ea11cc2b1e9',
                                value: 100
                            },
                            {
                                questionId: '4124546f-5321-472a-a9a2-7872f52ab393',
                                value: 200
                            },
                            {
                                questionId: 'b18e32e2-c796-4130-b147-86193ba8c5e3',
                                value: 300
                            },
                            {
                                questionId: '76ebf4f8-41a3-44f0-80e2-f676d31314d1',
                                value: 400
                            },
                            {
                                questionId: '485411ca-dfeb-43c5-91ab-0a3d5fa72c9a',
                                value: 500
                            }
                        ]
                    },
                ]
            },
            {
                id: 'ea1d0e97-88ed-4244-9eb3-ea6ee73577d1',
                type: 'Double',
                categories: [
                    {
                        id: '537e2ef1-64cd-4d99-8e5b-0f54cdb3a5e7',
                        name: 'Making a Splash',
                        questions: [
                            {
                                questionId: 'b77fb1ea-9b1b-4322-972c-315549a8b190',
                                value: 200
                            },
                            {
                                questionId: '8e2bd8ee-fb73-45a9-ba24-c9bf6d228257',
                                value: 400
                            },
                            {
                                questionId: 'fee39768-5f4e-41ef-a434-071438415192',
                                value: 600
                            },
                            {
                                questionId: '86a7ccd9-41d1-4fea-b24f-140af68ce6ee',
                                value: 800
                            },
                            {
                                questionId: '5ff250ac-95e4-4d26-9a11-5a331dbe524e',
                                value: 1000
                            }
                        ]
                    },
                    {
                        id: '181a6157-1c47-4e57-823f-d547ad7bd18c',
                        name: 'A Match Made in Heaven',
                        questions: [
                            {
                                questionId: 'e8ea9b0c-2dd0-4516-b094-4040edc38603',
                                value: 200
                            },
                            {
                                questionId: '7f61249a-8e75-411a-af82-f15a010563c9',
                                value: 400
                            },
                            {
                                questionId: '230d654b-1c51-46f8-a26d-16acf473bfa7',
                                value: 600
                            },
                            {
                                questionId: '12d5fa9c-3175-448b-9ad1-ee5f34499b04',
                                value: 800
                            },
                            {
                                questionId: '5970129b-de08-432c-8b27-abb18e9e27d7',
                                value: 1000
                            }
                        ]
                    },
                    {
                        id: '52b12ccb-62dd-4463-98b3-e782e4c3f842',
                        name: 'Rising Stars',
                        questions: [
                            {
                                questionId: '0ddf0d94-73a0-4b42-b95c-0be488ed937f',
                                value: 200
                            },
                            {
                                questionId: '38b76464-bae9-4293-9879-83c813fdc298',
                                value: 400
                            },
                            {
                                questionId: 'bb0991a7-e4db-4b41-8283-2f69ced18de5',
                                value: 600
                            },
                            {
                                questionId: '4e1941ca-d413-453d-8f95-07f1b84a12a1',
                                value: 800
                            },
                            {
                                questionId: '2ca7c778-6739-4ab7-a4a0-34392f509c89',
                                value: 1000
                            }
                        ]
                    },
                    {
                        id: '12606096-9cb4-4cae-ac6b-b58296e62152',
                        name: 'Lost Cities',
                        questions: [
                            {
                                questionId: 'b4c97560-d291-4c4d-a987-bf9922103ad6',
                                value: 200
                            },
                            {
                                questionId: 'b9cd8345-9793-463b-b3e1-f6b71799849b',
                                value: 400
                            },
                            {
                                questionId: '488588d4-e3bb-4dda-a644-8758b4aaa287',
                                value: 600
                            },
                            {
                                questionId: '474255a4-a160-4dfc-9fcc-a495e5e1167b',
                                value: 800
                            },
                            {
                                questionId: '9d50f70f-a4e4-4d81-92d7-2c1825d3ff28',
                                value: 1000
                            }
                        ]
                    },
                    {
                        id: 'e0989a35-a762-469d-a351-bcedb98a67f4',
                        name: 'Clash of the Titans',
                        questions: [
                            {
                                questionId: '5499d4be-156b-4e5a-91ce-9a4c5871e5dd',
                                value: 200
                            },
                            {
                                questionId: '2e52e3ea-3451-4c76-a1a4-ad8cdc27b83f',
                                value: 400
                            },
                            {
                                questionId: '3651d56d-0059-447e-ad08-8c2f72295b27',
                                value: 600
                            },
                            {
                                questionId: '00937294-311d-4aa1-affd-0d961540659b',
                                value: 800
                            },
                            {
                                questionId: '4b647e8d-66e4-4e7e-8dfd-8f83aeba1f33',
                                value: 1000
                            }
                        ]
                    }
                ]
            }
        ]
    }
];