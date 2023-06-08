export default (contextApp) => new App(contextApp);
var WEB;
class App {

    constructor(contextApp) {

        WEB = contextApp;
    }

    showTextPage2(text)
    {
        WEB.namedCommands["PageTwoCommand"](text);
    }

    showTextPage1(text) {
        WEB.namedCommands["PageOneCommand"](text);
    }
}