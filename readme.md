# Sample Fn App with NLog integration + Application Insights

1. Build this image
2. Push this image to ACR
3. Create a Fn on ACA app using the image pushed to the ACR, (and enable application insights as part of the creation flow via portal)
4. Update the App Settings with following nlog config specific appsettings:

    ```json
    {
        "name": "NLog__extensions__0__assembly",
        "value": "Microsoft.ApplicationInsights.NLogTarget"
    },
    {
        "name": "NLog__internalLogFile",
        "value": "Logs\\nlog.txt"
    },
    {
        "name": "NLog__internalLogLevel",
        "value": "Error"
    },
    {
        "name": "NLog__rules__0__minlevel",
        "value": "Info"
    },
    {
        "name": "NLog__rules__0__name",
        "value": "*"
    },
    {
        "name": "NLog__rules__0__writeTo",
        "value": "aiTarget"
    },
    {
        "name": "NLog__targets__aiTarget__type",
        "value": "ApplicationInsightsTarget"
    },
    {
        "name": "NLog__throwConfigExceptions",
        "value": "true"
    }
    ```