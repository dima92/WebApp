import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { enableProdMode } from '@angular/core';
import { AppModule } from './app/app.module';
import 'hammerjs';
enableProdMode();
const platform = platformBrowserDynamic();
platform.bootstrapModule(AppModule);
//# sourceMappingURL=main.js.map