// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  baseUrl: 'https://localhost:54971/api',
  production: false,
  options: {
    redirectUri: "http://localhost:4200/",
    protectedResourceMap: [],
      appId: "c832c923-37c6-4145-8c75-a023ecc7a98f",
    authority: "https://login.microsoftonline.com/tfp/DeltanHackaton.onmicrosoft.com/B2C_1_susi/"
  }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
