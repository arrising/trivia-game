import { defaultEnvironment } from "./environment.default";

export const environment = {
    ...defaultEnvironment,
    production: true,
    apiUrl: 'http://my-api-url'
};
